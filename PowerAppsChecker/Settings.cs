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
        public string SolutionFile { get; set; }
    }
}
