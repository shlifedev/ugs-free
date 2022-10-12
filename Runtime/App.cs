using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core;
using UnityEngine;

namespace UGS.Runtime
{

    /// <summary>
    /// 
    /// </summary>
    public static class UniGoogleSheets
    {
        private static int counter = 0;
        private static TypeMap typeMap;

      
        public static void Initialize()
        {
            counter++;
            Debug.Log(counter);
            typeMap = new TypeMap(); 
        }

        public static class Utility
        {
            /// <summary>
            /// [번역필요]
            /// UGS 내에 선언한 타입이 있다면 해당 타입에 대한 Read함수를 호출하여 결과를 반환합니다. 
            /// </summary> 
            /// <param name="value">파싱하기 원하는 값</param>
            /// <returns></returns>
            public static T Read<T>(string value)
            {
                var type = typeof(T); 
                return (T) typeMap[type].Read(value); 
            }
        }
    }
}
