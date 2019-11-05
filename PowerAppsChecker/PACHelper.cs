using Microsoft.CodeAnalysis.Sarif;
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

        private const string serviceUrl = "https://api.advisor.powerapps.com";

        #endregion Private Fields

        #region Public Methods

        public static AnalysisStatus GetAnalysisStatus(this HttpClient client, string statusurl)
        {
            var status = client.GetAsync(statusurl).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jss = new JavaScriptSerializer();
            return jss.Deserialize<AnalysisStatus>(status);
        }

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
            client.DefaultRequestHeaders.Add("accept", "application/json,application/x-ms-sarif-v2");
            client.DefaultRequestHeaders.Add("x-ms-tenant-id", tenantId.ToString());
            return client;
        }

        public static string GetResultFile(string fileurl)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json,application/x-ms-sarif-v2");
            var result = client.GetAsync(fileurl).GetAwaiter().GetResult().Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            var unzipped = Unzip(result);
            return unzipped;
        }

        public static Rule[] GetRules(Guid? rulesetid = null)
        {
            using (var client = new HttpClient())
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
        }

        public static RuleSet[] GetRuleSets()
        {
            using (var client = new HttpClient())
            {
                var rulesets = client.GetAsync($"{serviceUrl}/api/ruleset").GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jss = new JavaScriptSerializer();
                return jss.Deserialize<RuleSet[]>(rulesets);
            }
        }

        public static SarifLog GetSarifFromString(string resultstring)
        {
            var jss = new JavaScriptSerializer();
            return JsonConvert.DeserializeObject<SarifLog>(resultstring);
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

        public static string UploadSolution(this HttpClient client, Guid corrid, string filepath)
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
}