using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace UGS.Runtime.Packages.com.shlifedev.ugs.Runtime.CommonUtil
{
    internal class AssetLoader
    {
        public static T LoadAssetFromResources<T>(string path) where T : UnityEngine.Object
        {
#if UNITY_EDITOR
            var assetPath = PathUtil.GetPackageResourcesForEditor(path);
            return AssetDatabase.LoadAssetAtPath<T>(assetPath) as T;
#endif
        }
    }
}
