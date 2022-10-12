using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UGS.Runtime.Core.Exceptions;
using UGS.Runtime.Core.Interfaces;
using UnityEngine; 

namespace UGS.Runtime.Core
{
    internal class DeclaredType
    {
        public  readonly IType Type;
        private readonly MethodInfo Read;
        private readonly MethodInfo Write;
        private readonly PropertyInfo Declares;
        public Type BaseType => Read.ReturnType;
        public DeclaredType(IType type)
        {
            this.Type = type;
            Read  = type.GetType().GetMethod("Read");
            Write = type.GetType().GetMethod("Write");
            this.Declares = type.GetType().GetProperty("TypeDeclarations"); 
        }  
        public bool IsEnum()
        {
            return BaseType.IsEnum;
        }

        public List<string> GetDeclares() => Declares.GetValue(Type) as List<string>;
    }

    internal class TypeMap
    { 
        public Dictionary<string, DeclaredType> declares = new Dictionary<string, DeclaredType>();
        public static IEnumerable<System.Type> GetAllSubclassOf(System.Type parent)
        {
            var type = parent;
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            return types;
        }

        [InternalInit]
        public void Read()
        {  
            var subclasses = GetAllSubclassOf(typeof(Interfaces.IType));   
            foreach (var type in subclasses)
            {  
                if (type.IsClass)
                {
                    var typeReader = Activator.CreateInstance(type);
                    var declaredType = new DeclaredType(typeReader as IType);
                    var declareKeywords = declaredType.GetDeclares().Distinct();
                    foreach (var declamation in declareKeywords)
                    {
                        var lower = declamation.ToLower();
                        if (this.declares.ContainsKey(lower))
                        {
                            throw new DuplicateDeclareException();
                            //$"<color=red>{declaredType.Type.GetType().Namespace+"."+ declaredType.Type.GetType().Name}</color>"
                            // +$" Declare Duplicated Exception :: Already Used Declare Keyword <color=yellow>{declamation}</color> " + $"in {this.declares[lower].Type.GetType().Name}");
                        }
                        else
                        {
                            this.declares[lower] = declaredType;
                        }
                    }
                } 
            }
        }
    }
}
