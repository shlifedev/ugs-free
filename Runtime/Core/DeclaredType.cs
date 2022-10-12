using System;
using System.Collections.Generic;
using System.Reflection;
using UGS.Runtime.Core.Interfaces;

namespace UGS.Runtime.Core
{
    internal class DeclaredType
    {
        public readonly IType Type;
        public readonly Func<object, object> Read;
        public readonly MethodInfo ReadMethodInfo;
        public readonly Func<object, object> Write;
        private readonly PropertyInfo Declares;
        public Type BaseType => ReadMethodInfo.ReturnType;
        public DeclaredType(IType type)
        {
            this.Type = type; 
            ReadMethodInfo = type.GetType().GetMethod("Read");
            Read = (value) =>
            { 
                var obj = ReadMethodInfo?.Invoke(Type, new object[]{ value });
                return obj;
            };
            Write = null;
            this.Declares = type.GetType().GetProperty("TypeDeclarations"); 
        }  
        public bool IsEnum()
        {
            return BaseType.IsEnum;
        }

        public List<string> GetDeclares() => Declares.GetValue(Type) as List<string>;
    }
}