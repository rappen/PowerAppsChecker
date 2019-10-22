using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Rappen.XTB.PAC.Helpers
{
    public static class PACHelper
    {
        private const string serviceUrl = "https://api.advisor.powerapps.com";

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

        public static string Get(this HttpClient client, string method)
        {
            var apiUrl = $"{serviceUrl}/api/{method}";
            return client.GetAsync(apiUrl).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
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

        public static Uri Analyze(this HttpClient client, Guid corrid, string fileurl, PACRuleSet[] rulesets, PACRule[] rules, string[] exclusions)
        {
            var apiUrl = $"{serviceUrl}/api/analyze";
            var values = new Dictionary<string, string>
            {
                { "sasUriList", $"[\"{fileurl}\"]"},
            };
            if (rulesets != null)
            {
                values.Add("ruleSets", $"[{{{string.Join(", ", rulesets.Select(s => $"\"id\": \"{s.Id}\""))}}}");
            }
            else if (rules != null)
            {
                values.Add("ruleCodes", $"[{{{string.Join(", ", rules.Select(r => $"\"code\": \"{r.Code}\""))}}}");
            }
            if (exclusions != null)
            {
                values.Add("fileExclusions", $"[{string.Join(", ", exclusions.Select(f => $"\"{f}\""))}");
            }
            var body = new FormUrlEncodedContent(values);
            client.DefaultRequestHeaders.Add("x-ms-correlation-id", corrid.ToString());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json, application/x-ms-sarif-v2"));
            var response = client.PostAsync(apiUrl, body).GetAwaiter().GetResult();
            return response.Headers.Location;
        }
    }

    public class PACRuleSet
    {
        public Guid Id;
        public string Name;
        public PACRuleSet() { }
        //public PACRuleSet(string id, string name)
        //{
        //    Id = new Guid(id);
        //    Name = name;
        //}
        public override string ToString()
        {
            return Name;
        }
    }

    public class PACRule
    {
        public string Code;
        public string Summary;
        public string Description;
        public int ComponentType;
        public int PrimaryCategory;
        public int Severity;
        public bool Include;
        public string GuidanceUrl;
        public PACRule() { }
        public override string ToString()
        {
            return Code;
        }
    }
}