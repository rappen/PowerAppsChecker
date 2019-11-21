using Microsoft.CodeAnalysis.Sarif;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
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
    public static class PACHelper
    {
        #region Private Fields

        private const string serviceUrl = "https://{0}api.advisor.powerapps.com";
        private const string redirectUrl = "urn:ietf:wg:oauth:2.0:oob";

        #endregion Private Fields

        #region Public Methods

        public static AnalysisStatus GetAnalysisStatus(this HttpClient client, string statusurl)
        {
            if (client == null)
            {
                return null;
            }
            var status = client.GetAsync(statusurl).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jss = new JavaScriptSerializer();
            return jss.Deserialize<AnalysisStatus>(status);
        }

        public static HttpClient GetClient(string region, Guid tenantId, Guid clientId, string clientSec)
        {
            var resource = string.Format(serviceUrl, region);
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials"},
                { "client_id", clientId.ToString() },
                { "client_secret", clientSec},
                { "resource", resource}
            };
            var body = new FormUrlEncodedContent(values);
            var authUrl = $"https://login.microsoftonline.com/{tenantId}/oauth2/token";
            var response = client.PostAsync(authUrl, body).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                dynamic respdata = new JavaScriptSerializer().Deserialize<dynamic>(responseString);
                var error = respdata["error_description"];
                throw new Exception(response.ReasonPhrase + "\n" + error);
            }
            var token = responseString.Split(new string[] { "\"access_token\":\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
            token = token.Split(new string[] { "\"}" }, StringSplitOptions.RemoveEmptyEntries)[0];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Add("accept", "application/json,application/x-ms-sarif-v2");
            client.DefaultRequestHeaders.Add("x-ms-tenant-id", tenantId.ToString());
            return client;
        }

        public static HttpClient GetClient(string region, Guid clientId)
        {
            var resource = string.Format(serviceUrl, region);
            // Dummy endpoint just to get unauthorized response
            var query = $"{resource}/api/status/4799049A-E623-4B2A-818A-3A674E106DE5";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(query));

            using (var response = client.SendAsync(request).GetAwaiter().GetResult())
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    // Method below found here: https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/wiki/Acquiring-tokens-interactively---Public-client-application-flows
                    var authParams = AuthenticationParameters.CreateFromUnauthorizedResponseAsync(response).GetAwaiter().GetResult();
                    var authContext = new AuthenticationContext(authParams.Authority);
                    var authResult = authContext.AcquireTokenAsync(
                        resource,
                        clientId.ToString(),
                        new Uri(redirectUrl),
                        new PlatformParameters(PromptBehavior.Auto)).GetAwaiter().GetResult();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                    client.DefaultRequestHeaders.Add("accept", "application/json,application/x-ms-sarif-v2");
                    return client;
                }
                else
                {
                    throw new Exception($"Unable to connect to the service for authorization information. {response.ReasonPhrase}");
                }
            }
        }

        public static string GetResultFile(string fileurl)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json,application/x-ms-sarif-v2");
            var result = client.GetAsync(fileurl).GetAwaiter().GetResult().Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            var unzipped = Unzip(result);
            return unzipped;
        }

        public static Rule[] GetRules(string region, Guid? rulesetid = null)
        {
            using (var client = new HttpClient())
            {
                var url = $"{string.Format(serviceUrl, region)}/api/rule";
                if (rulesetid != null)
                {
                    url += $"?ruleset={rulesetid}";
                }
                var rules = client.GetAsync(url).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jss = new JavaScriptSerializer();
                return jss.Deserialize<Rule[]>(rules);
            }
        }

        public static RuleSet[] GetRuleSets(string region)
        {
            using (var client = new HttpClient())
            {
                var rulesets = client.GetAsync($"{string.Format(serviceUrl, region)}/api/ruleset").GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jss = new JavaScriptSerializer();
                return jss.Deserialize<RuleSet[]>(rulesets);
            }
        }

        public static SarifLog GetSarifFromString(string resultstring)
        {
            var jss = new JavaScriptSerializer();
            return JsonConvert.DeserializeObject<SarifLog>(resultstring);
        }

        public static HttpResponseMessage SendAnalysis(this HttpClient client, string region, AnalysisArgs args)
        {
            if (client == null)
            {
                return null;
            }
            var apiUrl = $"{string.Format(serviceUrl, region)}/api/analyze";
            var values = new Dictionary<string, string>
            {
                { "sasUriList", $"[{string.Join(", ", args.Solutions.Select(s => $"\"{s.UploadUrl}\""))}]"},
            };
            if (args.RuleSets != null && args.RuleSets.Count > 0)
            {
                values.Add("ruleSets", $"[{{{string.Join(", ", args.RuleSets.Select(s => $"\"id\": \"{s.Id}\""))}}}]");
            }
            else if (args.Rules != null)
            {
                values.Add("ruleCodes", $"[{string.Join(", ", args.Rules.Select(r => $"{{\"code\": \"{r.Code}\", \"include\": \"true\"}}"))}]");
            }
            if (args.FileExclusions != null)
            {
                values.Add("fileExclusions", $"[{string.Join(", ", args.FileExclusions.Select(f => $"\"{f}\""))}]");
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

        public static string UploadSolution(this HttpClient client, string region, Guid corrid, string filepath)
        {
            if (client == null)
            {
                return null;
            }
            var apiUrl = $"{string.Format(serviceUrl, region)}/api/upload";
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
}