﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

namespace UGS.Runtime
{
    public enum CodegenOption
    {
        UnUse = 0,
        Use = 1,
        Both = 2
    }

    public static class UniGoogleSheets
    {  
        private static TypeMap typeMap;

      
        /// <summary>
        /// 어플리케이션 로드 시점에 호출
        /// </summary>
        /// <param name="option"></param>
        public static void Initialize(CodegenOption option = CodegenOption.Use)
        {
            Profiler.enabled = true;
            typeMap = new TypeMap();
            Profiler.BeginSample("ugs");
            Internal.LoadAllLocalSchemas();

            Profiler.EndSample(); 
            Profiler.enabled = false;
        }


        static class Internal
        {
            public static void LoadAllLocalSchemas()
            {
                var schemas = AssetLoader.GetAllResourcesSchemas();
                foreach (var schema in schemas)
                {
                    var meta = schema.Meta;
                    var fullName = meta.Namespace + "." + meta.FileName;
                    var type = Utility.GetSchemaAssembly().GetType(fullName);
                    // fake instance for avoid generic
                    var instance = Activator.CreateInstance(type);
                    var method = type.GetMethod("Bind");
                    method?.Invoke(instance, new object[] { schema }); 
                } 
            }
        }
         

        public static class Utility
        { 
            public static T Read<T>(string value)
            {
                var type = typeof(T);
                return (T)typeMap[type].Read(value);
            }
            public static object Read(System.Type type, string value)
            {
                return typeMap[type].Read(value);
            }
            public static object Read(string declareType, string value)
            {
                return typeMap[declareType].Read(value);
            }

            public static List<string> KeysOf(SpreadSheetData data)
            {
                return data.Columns.First().Values.Select(x => x.ToString()).ToList();
            }
             

            public static Type DeclareToType(string declare)
            {
                return typeMap[declare].BaseType; 
            }

            public static Assembly GetSchemaAssembly()
            {
                return Assembly.Load("UniGoogleSheets.Runtime.Schemas"); ;

            }

            public static Assembly GetAssembly()
            {
                return Assembly.Load("UniGoogleSheets.Runtime"); 

            }
        }
    }
}
