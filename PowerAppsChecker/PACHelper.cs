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

        private const string resourceUrl = "https://api.advisor.powerapps.com";
        private const string redirectUrl = "urn:ietf:wg:oauth:2.0:oob";

        #endregion Private Fields

        #region Public Methods

        public static AnalysisStatus GetAnalysisStatus(PACClientInfo clientinfo, string statusurl)
        {
            var client = GetClient(clientinfo, PromptBehavior.Auto);
            if (client == null)
            {
                return null;
            }
            var status = client.GetAsync(statusurl).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jss = new JavaScriptSerializer();
            return jss.Deserialize<AnalysisStatus>(status);
        }

        public static HttpClient GetClient(PACClientInfo clientInfo, PromptBehavior behavior)
        {
            if (clientInfo.ClientId.Equals(Guid.Empty))
            {
                throw new ArgumentNullException("clientId");
            }
            if (string.IsNullOrEmpty(clientInfo.Token))
            {
                if (!clientInfo.TenantId.Equals(Guid.Empty) && !string.IsNullOrEmpty(clientInfo.ClientSec))
                {
                    clientInfo.Token = GetApplicationClientToken(clientInfo);
                }
                else if (!string.IsNullOrEmpty(clientInfo.ServiceUrl))
                {
                    clientInfo.Token = GetInteractiveClientToken(clientInfo, behavior);
                }
            }
            if (!string.IsNullOrEmpty(clientInfo.Token))
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", clientInfo.Token);
                client.DefaultRequestHeaders.Add("accept", "application/json,application/x-ms-sarif-v2");
                client.DefaultRequestHeaders.Add("x-ms-tenant-id", clientInfo.TenantId.ToString());
                return client;
            }
            throw new ArgumentException("Not enough parameters to connect PAC Client");
        }

        private static string GetApplicationClientToken(PACClientInfo clientInfo)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials"},
                { "client_id", clientInfo.ClientId.ToString() },
                { "client_secret", clientInfo.ClientSec },
                { "resource", resourceUrl }
            };
            var body = new FormUrlEncodedContent(values);
            var authUrl = $"https://login.microsoftonline.com/{clientInfo.TenantId}/oauth2/token";
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
            return token;
        }

        private static string GetInteractiveClientToken(PACClientInfo clientInfo, PromptBehavior behavior)
        {
            // Dummy endpoint just to get unauthorized response
            var client = new HttpClient();
            var query = $"{clientInfo.ServiceUrl}/api/status/4799049A-E623-4B2A-818A-3A674E106DE5";
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(query));

            using (var response = client.SendAsync(request).GetAwaiter().GetResult())
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    // Method below found here: https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/wiki/Acquiring-tokens-interactively---Public-client-application-flows
                    var authParams = AuthenticationParameters.CreateFromUnauthorizedResponseAsync(response).GetAwaiter().GetResult();
                    var authContext = new AuthenticationContext(authParams.Authority);
                    var authResult = authContext.AcquireTokenAsync(
                        resourceUrl,
                        clientInfo.ClientId.ToString(),
                        new Uri(redirectUrl),
                        new PlatformParameters(behavior)).GetAwaiter().GetResult();
                    return authResult.AccessToken;
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

        public static Rule[] GetRules(string serviceUrl, string language, Guid? rulesetid = null)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(language))
                {
                    client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(language));
                }
                var url = $"{serviceUrl ?? resourceUrl}/api/rule";
                if (rulesetid != null)
                {
                    url += $"?ruleset={rulesetid}";
                }
                var rules = client.GetAsync(url).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jss = new JavaScriptSerializer();
                return jss.Deserialize<Rule[]>(rules);
            }
        }

        public static RuleSet[] GetRuleSets(string serviceUrl)
        {
            using (var client = new HttpClient())
            {
                var rulesets = client.GetAsync($"{serviceUrl ?? resourceUrl}/api/ruleset").GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jss = new JavaScriptSerializer();
                return jss.Deserialize<RuleSet[]>(rulesets);
            }
        }

        public static SarifLog GetSarifFromString(string resultstring)
        {
            var jss = new JavaScriptSerializer();
            return JsonConvert.DeserializeObject<SarifLog>(resultstring);
        }

        public static HttpResponseMessage SendAnalysis(PACClientInfo clientinfo, AnalysisArgs args)
        {
            var client = GetClient(clientinfo, PromptBehavior.Auto);
            if (client == null)
            {
                return null;
            }
            var apiUrl = $"{clientinfo.ServiceUrl}/api/analyze";
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
            if (!string.IsNullOrEmpty(clientinfo.Language))
            {
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(clientinfo.Language));
            }
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

        public static string UploadSolution(PACClientInfo clientinfo, Guid corrid, string filepath)
        {
            var client = GetClient(clientinfo, PromptBehavior.Auto);
            if (client == null)
            {
                return null;
            }
            var apiUrl = $"{clientinfo.ServiceUrl}/api/upload";
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