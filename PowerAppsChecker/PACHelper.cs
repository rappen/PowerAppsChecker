﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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
            return Get(client, new Uri($"{serviceUrl}/api/{method}"));
        }

        public static string Get(this HttpClient client, Uri apiUrl)
        {
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

        public static Uri Analyze(this HttpClient client, PACAnalysisArgs args)
        {
            var apiUrl = $"{serviceUrl}/api/analyze";
            var values = new Dictionary<string, string>
            {
                { "sasUriList", $"[\"{args.FileUrl}\"]"},
            };
            if (args.RuleSets != null)
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
            //var body = new FormUrlEncodedContent(values);
            var body = new StringContent(
                "{" + 
                    string.Join(",",
                        values.Select(v => "\"" + v.Key + "\":" + v.Value )) +
                "}", Encoding.UTF8);
            client.DefaultRequestHeaders.Add("x-ms-correlation-id", args.CorrId.ToString());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
        public Category PrimaryCategory;
        public Severity Severity;
        public bool Include;
        public string GuidanceUrl;
        public PACRule() { }
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Summary) ? Code : Summary;
        }
    }

    public class PACStatus
    {
        public string Status;
        public int Progress;
        public Guid RunCorrelationId;
        public string[] ResultFileUris;
        public PACStatusSummary IssueSummary;
        public PACStatus() { }
        public override string ToString()
        {
            return $"{Status} / {Progress}";
        }
    }

    public class PACStatusSummary
    {
        public int CriticalIssueCount;
        public int HighIssueCount;
        public int MediumIssueCount;
        public int LowIssueCount;
        public int InformationalIssueCount;
    }

    public class PACAnalysisArgs
    {
        public Guid CorrId;
        public string FileUrl;
        public List<PACRuleSet> RuleSets;
        public List<PACRule> Rules;
        public List<string> Exclusions;
    }

    public enum Severity
    {
        Informational = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        Critical = 5
    }

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
}