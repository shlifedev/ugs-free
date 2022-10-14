using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core;
using UnityEditor;

using UnityEngine;

namespace UGS.Test
{
    public class UGSTestMenu
    {
#if UNITY_EDITOR
        [MenuItem("Test/TypeChecker")]
        public static void Test()
        {
            var ctx = new TypeChecker();
            foreach (var data in ctx.GetTypeMap())
            {
                Debug.Log($"<color=yellow>{data.Key}</color> 는 <color=orange>{data.Value.Type}</color> 을 사용하여 파싱됩니다.");
            }
        }
#endif
    }
}

 