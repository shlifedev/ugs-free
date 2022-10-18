using System.Collections.Generic;
using UGS.Runtime;
using UGS.Runtime.Core;
using UGS.Runtime.Interfaces;
using UnityEditor;

using UnityEngine;

namespace UGS.Test
{
  public class UGSTestMenu
    {
#if UNITY_EDITOR
        [MenuItem("UGS/Test/TypeChecker")]
        public static void Test()
        {
            var ctx = new TypeChecker();
            foreach (var data in ctx.GetTypeMap())
            {
                Debug.Log($"<color=yellow>{data.Key}</color> 는 <color=orange>{data.Value.Type}</color> 을 사용하여 파싱됩니다.");
            }
        }
         [MenuItem("UGS/Test/Engine-Request")]
        public static void Test2()
        {
            
            var fetch = new UnityHttpRequest();
            var postData = new UGSBaseRequest.PostData<Dictionary<string, string>>("get-DriveFiles", new Dictionary<string, string>()
            {
                {"Id", ""}
            });
            
            fetch.Post(
                "https://script.google.com/macros/s/AKfycbxVD_8snEArj0YMhqz2lunGYnr6nDGtvB4CctxRkRAbXf4d0zGy-HZm--vwcpxbcuys/exec",
                null, JsonUtility.ToJson(postData), res =>
                {
                    Debug.Log(res);
                });
        }
#endif
    }
}

