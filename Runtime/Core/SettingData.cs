using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGS.Runtime
{
    internal abstract class SettingData
    {
        public abstract string DriveId { get; set; }
        public abstract string ScriptUrl { get; set; } 
    }
}
