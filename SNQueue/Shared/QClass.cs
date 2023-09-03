using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNQueue.Shared
{
    public class QClass
    {
        public static string? WorkingSiteName { get; set; } = "KING ABDULLAH HOSPITAL - REHAB";        
        public class PatInfoGet
        {
            public Int32 userId { get; set; }=0;
            public string? idType { get; set; } = string.Empty;
            public string? idValue { get; set; } = string.Empty;
        }
    }
}
