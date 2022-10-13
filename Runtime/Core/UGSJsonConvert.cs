using UnityEngine;

namespace UGS.Runtime.Core
{
    public static class UGSJsonConvert
    {
        public static SpreadSheetData ReadJson(string json)
        {
            return JsonUtility.FromJson<SpreadSheetData>(json);
        }
    }
}