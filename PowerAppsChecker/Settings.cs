using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappen.XTB.PAC
{
    public class Settings
    {
        public Guid TenantId { get; set; }
        public Guid ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Region { get; set; }
        public string SolutionFile { get; set; }
        public Guid CorrelationId { get; set; }
        public string UploadedFile { get; set; }
        public string FileExclusions { get; set; }
    }
}
