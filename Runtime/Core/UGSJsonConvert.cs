using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core;
using UnityEngine;

namespace UGS.Runtime.Core { 
    public  static class UGSJsonConvert
    {
        public static SpreadSheetData ReadJson(string json)
        {
            return JsonUtility.FromJson<SpreadSheetData>(json);
        }
    }
}
