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
        public string SolutionName { get; set; }
        public string SolutionFile { get; set; }
        public Guid CorrelationId { get; set; }
        public string UploadedFile { get; set; }
        public string FileExclusions { get; set; }
    }

    public enum AuthMethod
    {
        User,
        Secret
    }
}
