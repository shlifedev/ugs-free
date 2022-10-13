using System.Collections.Generic;
using System.Linq;
using UGS.Runtime.Core;
using UnityEngine;

namespace UGS.Runtime
{
    internal class AssetLoader
    {
        public static T FromUGSData<T>(string path) where T : Object
        {
#if UNITY_EDITOR
            return Resources.Load<T>("@ugs-datas/" + path);
#endif
        }

        public static IEnumerable<SpreadSheetData> GetAllResourcesSchemas()
        {
            var schemas = Resources.LoadAll<TextAsset>("@ugs-datas/@schemas");
            return schemas.Select(x => JsonUtility.FromJson<SpreadSheetData>(x.text));
        }
    }
}