using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core;
using UnityEngine;

namespace UGS.Runtime
{

    public class SchemaMap
    {
        public Dictionary<Type, ISheetSchema> sheetSchemas = new Dictionary<Type, ISheetSchema>();
       
    } 
    public static class UniGoogleSheets
    {
        public enum CodegenOption
        {
            UnUse = 0,
            Use = 1,
            Both = 2
        } 
        private static TypeMap typeMap;

      
        public static void Initialize(CodegenOption option = CodegenOption.Use)
        { 
            typeMap = new TypeMap(); 
        }

        public static T GetSchema<T>()
        {
            
            return default;
        }


        public static class Utility
        {
            /// <summary> 
            /// UGS 내에 선언한 타입이 있다면 해당 타입에 대한 Read함수를 호출하여 결과를 반환합니다. 
            /// </summary> 
            /// <param name="value">파싱하기 원하는 값</param>
            /// <returns></returns>
            public static T Read<T>(string value)
            {
                var type = typeof(T);
                return (T)typeMap[type].Read(value);
            }
            public static T Read<T>(System.Type type, string value)
            {
                return (T)typeMap[type].Read(value);
            }

            public static string[] KeysOf(SpreadSheetData data)
            {
                return data.Columns.First().Values;
            }
            public static Type DeclareToType(string declare)
            {
                return typeMap[declare].BaseType; 
            }
        }
    }
}
