using Microsoft.CodeAnalysis.Sarif.Readers;
using Microsoft.CodeAnalysis.Sarif.VersionOne;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials"},
                { "client_id", clientId.ToString() },
                { "client_secret", clientSec},
                { "resource", serviceUrl}
            };
            var body = new FormUrlEncodedContent(values);
            var authUrl = $"https://login.microsoftonline.com/{tenantId}/oauth2/token";
            var response = client.PostAsync(authUrl, body).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var token = responseString.Split(new string[] { "\"access_token\":\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
            token = token.Split(new string[] { "\"}" }, StringSplitOptions.RemoveEmptyEntries)[0];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Add("x-ms-tenant-id", tenantId.ToString());
            return client;
        }

        public static SarifLogVersionOne GetResultFile(string fileurl)
        {
            var client = new HttpClient();
            var resultstring = client.GetAsync(fileurl).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jss = new JavaScriptSerializer();
            var settings = new JsonSerializerSettings
            {
                ContractResolver = SarifContractResolverVersionOne.Instance
            };
            return JsonConvert.DeserializeObject<SarifLogVersionOne>(resultstring, settings);
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

        public static AnalysisStatus GetStatus(this HttpClient client, string statusurl)
        {
            var status = client.GetAsync(statusurl).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jss = new JavaScriptSerializer();
            return jss.Deserialize<AnalysisStatus>(status);
        }

        public static Uri SendAnalysis(this HttpClient client, AnalysisArgs args)
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
                values.Add("ruleCodes", $"[{{{string.Join(", ", args.Rules.Select(r => $"\"code\": \"{r.Code}\""))}}}]");
            }
            if (args.Exclusions != null)
            {
                values.Add("fileExclusions", $"[{string.Join(", ", args.Exclusions.Select(f => $"\"{f}\""))}]");
            }
            var bodystr = "{" + string.Join(",", values.Select(v => "\"" + v.Key + "\":" + v.Value)) + "}";
            var body = new StringContent(bodystr, Encoding.UTF8);
            client.DefaultRequestHeaders.Add("x-ms-correlation-id", args.CorrId.ToString());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(apiUrl, body).GetAwaiter().GetResult();
            return response.Headers.Location;
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

    public class Rule
    {
        #region Public Fields

        public string Code;
        public int ComponentType;
        public string Description;
        public string GuidanceUrl;
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
            return string.IsNullOrWhiteSpace(Summary) ? Code : Summary;
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

        //public PACRuleSet(string id, string name)
        //{
        //    Id = new Guid(id);
        //    Name = name;
        //}
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
}