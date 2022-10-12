using System;
using System.Collections.Generic;
using System.Linq;
using UGS.Runtime.Core.Exceptions;
using UGS.Runtime.Core.Interfaces;
using UnityEngine; 

namespace UGS.Runtime.Core
{
    internal class TypeMap
    { 
        public DeclaredType this[string key] => declares[key];
        public DeclaredType this[Type key] => declaresWithType[key];

        private Dictionary<string, DeclaredType> declares;
        private Dictionary<Type, DeclaredType> declaresWithType;
        private IEnumerable<System.Type> GetAllSubclassOf(System.Type parent)
        {
            var type = parent;
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            return types;
        }
         


        public TypeMap()
        {
            Initialize();
        }
        public DeclaredType GetDeclare(string key)
        {
            return declares[key];
        }
        public DeclaredType GetDeclare(Type key)
        {
            return declaresWithType[key];
        }

         
        [InternalInit]
        public void Initialize()
        { 
            declares = new Dictionary<string, DeclaredType>();
            declaresWithType = new Dictionary<Type, DeclaredType>();
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
                            this.declaresWithType[declaredType.BaseType] = declaredType;
                        }
                    }
                } 
            }
        }
    }
}
