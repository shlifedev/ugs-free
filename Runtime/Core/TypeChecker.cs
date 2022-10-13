using System;
using System.Collections.Generic;
using System.Linq;
using UGS.Runtime.Core.Exceptions;
using UGS.Runtime.Core.Interfaces;
using UnityEngine; 

namespace UGS.Runtime.Core
{
    internal class TypeChecker
    { 
        public DeclaredType this[string key] => _declares[key];
        public DeclaredType this[Type key] => _declaresWithType[key];

        private Dictionary<string, DeclaredType> _declares;
        private Dictionary<Type, DeclaredType> _declaresWithType;
        private IEnumerable<System.Type> GetAllSubclassOf(System.Type parent)
        {
            var type = parent;
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            return types;
        }
         


        public TypeChecker()
        {
            Initialize();
        }
        public DeclaredType GetDeclare(string key)
        {
            return _declares[key];
        }
        public DeclaredType GetDeclare(Type key)
        {
            return _declaresWithType[key];
        }

         
        [InternalInit]
        public void Initialize()
        { 
            _declares = new Dictionary<string, DeclaredType>();
            _declaresWithType = new Dictionary<Type, DeclaredType>();
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
                        if (this._declares.ContainsKey(lower))
                        {
                            throw new DuplicateDeclareException();
                            //$"<color=red>{declaredType.Type.GetType().Namespace+"."+ declaredType.Type.GetType().Name}</color>"
                            // +$" Declare Duplicated Exception :: Already Used Declare Keyword <color=yellow>{declamation}</color> " + $"in {this.declares[lower].Type.GetType().Name}");
                        }
                        else
                        {
                            this._declares[lower] = declaredType;
                            this._declaresWithType[declaredType.BaseType] = declaredType;
                        }
                    }
                } 
            }
        }
    }
}
