using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappen.XTB.PAC
{
    public class Settings
    {
        public AuthMethod AuthMethod { get; set; } = AuthMethod.User;
        public Guid TenantId { get; set; }
        public Guid ClientIdForUser { get; set; }
        public Guid ClientIdForSecret { get; set; }
        public string ClientSecret { get; set; }
        public string Region { get; set; } = "Default";
        public string ServiceUrl { get; set; }
        public string Language { get; set; } = "Default";
        public string SolutionName { get; set; }
        public string SolutionFile { get; set; }
        public string SolutionUri { get; set; }
        public Guid CorrelationId { get; set; }
        public string UploadedFile { get; set; }
        public string FileExclusions { get; set; }
        public List<string> Languages { get; set; } = new List<string>(new string[] { "Default", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "eu", "fi", "fr", "gl", "hi", "hr", "hu", "id", "it", "ja", "kk", "ko", "lt", "lv", "ms", "nb", "nl", "pl", "pt-BR", "pt-pt", "ro", "ru", "sk", "sl", "sr-Cyrl-RS", "sr-Latn-RS", "sv", "th", "tr", "uk", "vi", "zh-HANS", "zh-HANT" });
    }

    public enum AuthMethod
    {
        User,
        Secret
    }
}
