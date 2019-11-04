using Microsoft.CodeAnalysis.Sarif;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;

namespace Rappen.XTB.PAC.Helpers
{
    public enum Category
    {
        Performance = 1,
        UpgradeReadiness = 2,
        Usage = 3,
        Security = 4,
        Design = 5,
        OnlineMigration = 6,
        Maintainability = 7,
        Supportability = 8,
        Accessibility = 9
    }

    public enum Component
    {
        WebResource = 1,
        ManagedCode = 2,
        Configuration = 3
    }

    public enum Severity
    {
        Informational = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        Critical = 5
    }

    public static class PACHelper
    {
        #region Private Fields

        private const string serviceUrl = "https://api.advisor.powerapps.com";

        #endregion Private Fields

        #region Public Methods

        public static HttpClient GetClient(Guid tenantId, Guid clientId, string clientSec)
        {
            Uri queryUri = new Uri($"{serviceUrl}/api/status/4799049A-E623-4B2A-818A-3A674E106DE5");
            AuthenticationParameters authParams = null;

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, queryUri);
            request.Headers.Add("x-ms-tenant-id", tenantId.ToString());

            // NOTE - It is highly recommended to use async/await
            using (var response = client.SendAsync(request).GetAwaiter().GetResult())
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    // NOTE - It is highly recommended to use async/await
                    authParams = AuthenticationParameters.CreateFromUnauthorizedResponseAsync(response).GetAwaiter().GetResult();
                    var authContext = new AuthenticationContext(authParams.Authority, false);
                    var authResult = authContext.AcquireTokenAsync(queryUri.ToString(), clientId.ToString(), new UserCredential("jonas@jonasr.app"));
                    var authHeader = new AuthenticationHeaderValue("Bearer", authResult.GetAwaiter().GetResult().AccessToken);
                }
                else
                {
                    throw new Exception($"Unable to connect to the service for authorization information. {response.ReasonPhrase}");
                }
            }
            return client;

            //var client = new HttpClient();
            //var values = new Dictionary<string, string>
            //{
            //    { "grant_type", "client_credentials"},
            //    { "client_id", clientId.ToString() },
            //    { "client_secret", clientSec},
            //    { "resource", serviceUrl}
            //};
            //var body = new FormUrlEncodedContent(values);
            //var authUrl = $"https://login.microsoftonline.com/{tenantId}/oauth2/token";
            //var response = client.PostAsync(authUrl, body).GetAwaiter().GetResult();
            //var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //var token = responseString.Split(new string[] { "\"access_token\":\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
            //token = token.Split(new string[] { "\"}" }, StringSplitOptions.RemoveEmptyEntries)[0];
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //client.DefaultRequestHeaders.Add("accept", "application/json,application/x-ms-sarif-v2");
            //client.DefaultRequestHeaders.Add("x-ms-tenant-id", tenantId.ToString());
            //return client;
        }

        public static string GetResultFile(string fileurl)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json,application/x-ms-sarif-v2");
            var result = client.GetAsync(fileurl).GetAwaiter().GetResult().Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            var unzipped = Unzip(result);
            return unzipped;
        }

        public static Rule[] GetRules(this HttpClient client, Guid? rulesetid = null)
        {
            var url = $"{serviceUrl}/api/rule";
            if (rulesetid != null)
            {
                url += $"?ruleset={rulesetid}";
            }
            var rules = client.GetAsync(url).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jss = new JavaScriptSerializer();
            return jss.Deserialize<Rule[]>(rules);
        }

        public static RuleSet[] GetRuleSets(this HttpClient client)
        {
            var rulesets = client.GetAsync($"{serviceUrl}/api/ruleset").GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jss = new JavaScriptSerializer();
            return jss.Deserialize<RuleSet[]>(rulesets);
        }

        public static SarifLog GetSarifFromString(string resultstring)
        {
            var jss = new JavaScriptSerializer();
            return JsonConvert.DeserializeObject<SarifLog>(resultstring);
        }

        public static AnalysisStatus GetStatus(this HttpClient client, string statusurl)
        {
            var status = client.GetAsync(statusurl).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jss = new JavaScriptSerializer();
            return jss.Deserialize<AnalysisStatus>(status);
        }

        public static HttpResponseMessage SendAnalysis(this HttpClient client, AnalysisArgs args)
        {
            var apiUrl = $"{serviceUrl}/api/analyze";
            var values = new Dictionary<string, string>
            {
                { "sasUriList", $"[\"{args.FileUrl}\"]"},
            };
            if (args.RuleSets != null && args.RuleSets.Count > 0)
            {
                values.Add("ruleSets", $"[{{{string.Join(", ", args.RuleSets.Select(s => $"\"id\": \"{s.Id}\""))}}}]");
            }
            else if (args.Rules != null)
            {
                values.Add("ruleCodes", $"[{string.Join(", ", args.Rules.Select(r => $"{{\"code\": \"{r.Code}\", \"include\": \"true\"}}"))}]");
            }
            if (args.Exclusions != null)
            {
                values.Add("fileExclusions", $"[{string.Join(", ", args.Exclusions.Select(f => $"\"{f}\""))}]");
            }
            var bodystr = "{" + string.Join(",", values.Select(v => "\"" + v.Key + "\":" + v.Value)) + "}";
            var body = new StringContent(bodystr, Encoding.UTF8);
            client.DefaultRequestHeaders.Add("x-ms-correlation-id", args.CorrId.ToString());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client.PostAsync(apiUrl, body).GetAwaiter().GetResult();
        }

        public static string Unzip(byte[] zippedBuffer)
        {
            using (var zippedStream = new MemoryStream(zippedBuffer))
            {
                using (var archive = new ZipArchive(zippedStream))
                {
                    var entry = archive.Entries.FirstOrDefault();

                    if (entry != null)
                    {
                        using (var unzippedEntryStream = entry.Open())
                        {
                            using (var ms = new MemoryStream())
                            {
                                unzippedEntryStream.CopyTo(ms);
                                var unzippedArray = ms.ToArray();

                                return Encoding.Default.GetString(unzippedArray);
                            }
                        }
                    }

                    return null;
                }
            }
        }
        public static string Upload(this HttpClient client, Guid corrid, string filepath)
        {
            var apiUrl = $"{serviceUrl}/api/upload";
            var file = File.ReadAllBytes(filepath);
            var filename = Path.GetFileName(filepath);
            client.DefaultRequestHeaders.Add("x-ms-correlation-id", corrid.ToString());
            var reqcontent = new MultipartFormDataContent();
            reqcontent.Add(new ByteArrayContent(file), filename, filename);
            var result = client.PostAsync(apiUrl, reqcontent).GetAwaiter().GetResult();
            return result.Content.ReadAsStringAsync().GetAwaiter().GetResult().TrimStart('[').TrimEnd(']').Trim('"');
        }

        #endregion Public Methods
    }

    public class AnalysisArgs
    {
        #region Public Fields

        public Guid CorrId;
        public List<string> Exclusions;
        public string FileUrl;
        public List<Rule> Rules;
        public List<RuleSet> RuleSets;

        #endregion Public Fields
    }

    public class AnalysisStatus
    {
        #region Public Fields

        public StatusSummary IssueSummary;
        public int Progress;
        public string[] ResultFileUris;
        public Guid RunCorrelationId;
        public string Status;

        #endregion Public Fields

        #region Public Constructors

        public AnalysisStatus() { }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return $"{Status} / {Progress}";
        }

        #endregion Public Methods
    }

    public class Fix
    {
        #region Public Fields

        public string Summary;

        #endregion Public Fields

        #region Public Constructors

        public Fix() { }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return Summary;
        }

        #endregion Public Methods
    }

    public class Rule
    {
        #region Public Fields

        public string Code;
        public int ComponentType;
        public string Description;
        public string GuidanceUrl;
        public Fix HowToFix;
        public bool Include;
        public Category PrimaryCategory;
        public Severity Severity;
        public string Summary;
        #endregion Public Fields

        #region Public Constructors

        public Rule() { }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Description) ? Code : Description;
        }

        #endregion Public Methods
    }

    public class RuleSet
    {
        #region Public Fields

        public Guid Id;
        public string Name;

        #endregion Public Fields

        #region Public Constructors

        public RuleSet() { }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion Public Methods
    }

    public class SolutionItem
    {
        #region Public Fields

        public Entity Solution;

        #endregion Public Fields

        #region Public Constructors

        public SolutionItem(Entity solution)
        {
            Solution = solution;
        }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return Solution["friendlyname"].ToString();
        }

        #endregion Public Methods
    }

    public class StatusSummary
    {
        #region Public Fields

        public int CriticalIssueCount;
        public int HighIssueCount;
        public int InformationalIssueCount;
        public int LowIssueCount;
        public int MediumIssueCount;

        #endregion Public Fields
    }

    public class FlattenedResult
    {
        public string RuleId { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }
        public Uri FilePath { get; set; }
        public int? StartLine { get; set; }
        public int? EndLine { get; set; }
        public string Snippet { get; set; }
        public string Module { get; set; }

        public static List<FlattenedResult> GetFlattenedResults(Run run)
        {
            var query =
                run.Results
                .SelectMany(r => r.Locations, (result, location) => new FlattenedResult
                {
                    RuleId = result.RuleId,
                    Message = result.Message?.Text,
                    FilePath = location.PhysicalLocation?.ArtifactLocation?.Uri,
                    StartLine = location.PhysicalLocation?.Region?.StartLine,
                    Snippet = location.PhysicalLocation?.Region?.Snippet?.Text,
                    EndLine = location.PhysicalLocation?.Region?.EndLine,
                    Module = location.PropertyNames.Contains("module") ? location.GetProperty("module") : null,
                    Severity = result.PropertyNames.Contains("severity") ? result.GetProperty("severity") : null
                });
            return query.ToList();
        }
    }
}