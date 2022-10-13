using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UGS.Runtime.Core;
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
        private static TypeChecker _typeChecker;


        /// <summary>
        ///     어플리케이션 로드 시점에 호출
        /// </summary>
        /// <param name="option"></param>
        public static void Initialize(CodegenOption option = CodegenOption.Use)
        {
            Profiler.enabled = true;
            _typeChecker = new TypeChecker();
            Profiler.BeginSample("ugs");
            Internal.LoadAllLocalSchemas();

            Profiler.EndSample();
            Profiler.enabled = false;
        }


        private static class Internal
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
                return (T)_typeChecker[type].Read(value);
            }

            public static object Read(Type type, string value)
            {
                return _typeChecker[type].Read(value);
            }

            public static object Read(string declareType, string value)
            {
                return _typeChecker[declareType].Read(value);
            }

            public static List<string> KeysOf(SpreadSheetData data)
            {
                return data.Columns.First().Values.Select(x => x.ToString()).ToList();
            }


            public static Type DeclareToType(string declare)
            {
                return _typeChecker[declare].BaseType;
            }

            public static Assembly GetSchemaAssembly()
            {
                return Assembly.Load("UniGoogleSheets.Runtime.Schemas");
                ;
            }

            public static Assembly GetAssembly()
            {
                return Assembly.Load("UniGoogleSheets.Runtime");
            }
        }
    }
}