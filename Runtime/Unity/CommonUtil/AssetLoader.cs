using System.Collections.Generic;
using System.IO;
using System.Linq;
using UGS.Runtime.Core;
using UnityEngine;

namespace UGS.Runtime
{
    internal static class AssetLoader
    {
        public static FileStream OpenStreamAtStreaming(string path)
        {
            FileStream stream = new FileStream(Application.streamingAssetsPath + "/" + path, FileMode.OpenOrCreate);
            return stream;
        }


        public static IEnumerable<SpreadSheetData> GetAllResourcesSchemas()
        {
            var schemas = Resources.LoadAll<TextAsset>("@ugs-datas/@schemas");
            return schemas.Select(x => JsonUtility.FromJson<SpreadSheetData>(x.text));
        }
    }
}