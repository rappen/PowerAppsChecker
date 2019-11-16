﻿/* ***********************************************************
 * XTBAppInsights.cs
 * Found at: https://gist.github.com/rappen/fbdbb644b3fffec1305b00a51b007fa6
 * Created by: Jonas Rapp https://jonasr.app/
 * Immensely inspired by: code from Jason Lattimer https://github.com/jlattimer/D365AppInsights
 *
 * Simplifies logging to Azure Application Insights from XrmToolBox tools.
 *
 * Sample from tool constructor:
 *    ai = new AppInsights(new AiConfig("https://dc.services.visualstudio.com/v2/track", "[a guid that is the key to your appinsights resource]"));
 * Sample call:
 *    ai.WriteEvent(action, count, duration, HandleAIResult);
 * Sample HandleAIResult:
 *    private void HandleAIResult(string result)
 *    {
 *        if (!string.IsNullOrEmpty(result)) { LogError("Failed to write to Application Insights:\n{0}", result); }
 *    }
 *
 *               Enjoy responsibly.
 * **********************************************************/

using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

public class AppInsights
{
    private readonly AiConfig _aiConfig;
    private int seq = 1;

    public AppInsights(AiConfig aiConfig)
    {
        _aiConfig = aiConfig;
    }

    public void WriteEvent(string eventName, double? count = null, double? duration = null, Action<string> resultHandler = null)
    {
        if (!_aiConfig.LogEvents) return;
        var logRequest = GetLogRequest("Event");
        logRequest.Data.BaseData.Name = eventName;
        if (count != null || duration != null)
        {
            logRequest.Data.BaseData.Measurements = new AiMeasurements
            {
                Count = count ?? 0,
                Duration = duration ?? 0
            };
        }
        var json = SerializeRequest<AiLogRequest>(logRequest);
        SendToAi(json, resultHandler);
    }

    private async void SendToAi(string json, Action<string> handleresult = null)
    {
        var result = string.Empty;
#if DEBUG
#else
        try
        {
            using (HttpClient client = HttpHelper.GetHttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/x-json-stream");
                var response = await client.PostAsync(_aiConfig.AiEndpoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    result = response.ToString();
                }
            }
        }
        catch (Exception e)
        {
            result = e.ToString();
        }
#endif
        handleresult?.Invoke(result);
    }

    private AiLogRequest GetLogRequest(string action)
    {
        return new AiLogRequest(seq++, _aiConfig, action);
    }

    private static string SerializeRequest<T>(object o)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(stream, o);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();

            return json;
        }
    }
}

public class AiConfig
{
    public string PluginName { get; set; } = GetLastDotPart(Assembly.GetExecutingAssembly().GetName().Name);
    public string PluginVersion { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.PaddedVersion(1, 4, 2, 2);
    public string XTBVersion { get; set; } = GetLastDotPart(Assembly.GetEntryAssembly().GetName().Name) + " " + Assembly.GetEntryAssembly().GetName().Version.PaddedVersion(1, 4, 2, 2);
    public string OperationName { get; set; }
    public Guid SessionId { get; } = Guid.NewGuid();
    public string InstrumentationKey { get; }
    public string AiEndpoint { get; }
    public bool LogEvents { get; set; } = true;

    public AiConfig(string endpoint, string ikey)
    {
        AiEndpoint = endpoint;
        InstrumentationKey = ikey;
    }

    private static string GetLastDotPart(string identifier)
    {
        return identifier == null ? null : !identifier.Contains(".") ? identifier : identifier.Substring(identifier.LastIndexOf('.') + 1);
    }
}

public class HttpHelper
{
    public static HttpClient GetHttpClient()
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Connection", "close");

        return client;
    }
}

public static class Extensions
{
    public static string PaddedVersion(this Version version, int majorpad, int minorpad, int buildpad, int revisionpad)
    {
        return string.Format($"{{0:D{majorpad}}}.{{1:D{minorpad}}}.{{2:D{buildpad}}}.{{3:D{revisionpad}}}", version.Major, version.Minor, version.Build, version.Revision);
    }
}

#region DataContracts

[DataContract]
public class AiBaseData
{
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "measurements")]
    public AiMeasurements Measurements { get; set; }
}

[DataContract]
public class AiData
{
    [DataMember(Name = "baseType")]
    public string BaseType { get; set; }

    [DataMember(Name = "baseData")]
    public AiBaseData BaseData { get; set; }
}

[DataContract]
public class AiLogRequest
{
    public AiLogRequest(int sequence, AiConfig aiConfig, string action)
    {
        Name = $"Microsoft.ApplicationInsights.{aiConfig.InstrumentationKey}.{action}";
        Time = $"{DateTime.UtcNow:O}";
        Sequence = sequence.ToString("0000000000");
        InstrumentationKey = aiConfig.InstrumentationKey;
        Tags = new AiTags
        {
            OSVersion = aiConfig.XTBVersion,
            DeviceType = aiConfig.PluginName,
            ApplicationVersion = aiConfig.PluginVersion,
            SessionId = aiConfig.SessionId.ToString(),
            OperationName = aiConfig.OperationName
        };
        Data = new AiData
        {
            BaseType = $"{action}Data",
            BaseData = new AiBaseData()
        };
    }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "time")]
    public string Time { get; set; }

    [DataMember(Name = "iKey")]
    public string InstrumentationKey { get; set; }

    [DataMember(Name = "seq")]
    public string Sequence { get; set; }

    [DataMember(Name = "tags")]
    public AiTags Tags { get; set; }

    [DataMember(Name = "data")]
    public AiData Data { get; set; }
}

[DataContract]
public class AiMeasurements
{
    [DataMember(Name = "count")]
    public double Count { get; set; }

    [DataMember(Name = "duration")]
    public double Duration { get; set; }
}

[DataContract]
public class AiTags
{
    [DataMember(Name = "ai.session.id")]
    public string SessionId { get; set; } = Guid.NewGuid().ToString();

    [DataMember(Name = "ai.operation.name")]
    public string OperationName { get; set; }

    [DataMember(Name = "ai.application.ver")]
    public string ApplicationVersion { get; set; }

    [DataMember(Name = "ai.device.osVersion")]
    public string OSVersion { get; set; }

    [DataMember(Name = "ai.device.type")]
    public string DeviceType { get; set; }
}

#endregion DataContracts