using System;
using System.Collections.Generic;
using System.Linq;
using UGS.Runtime.Core.Exceptions;
using UGS.Runtime.Core.Types;
using UnityEngine; 

namespace UGS.Runtime.Core
{
    internal class TypeChecker
    { 
        public DeclaredType this[string key] => _declares[key];
        public DeclaredType this[Type key] => _declaresWithType[key];

        private static Dictionary<string, DeclaredType> _declares;
        private static Dictionary<Type, DeclaredType> _declaresWithType;
         
        private static IEnumerable<System.Type> _cached;
        private IEnumerable<System.Type> GetAllSubclassOf(System.Type parent)
        {
            if (_cached != null) return _cached; 
            var type = parent;
            _cached = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            return _cached;
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
            if (_declares != null && _declaresWithType != null) 
                return;

            _declares = new Dictionary<string, DeclaredType>();
            _declaresWithType = new Dictionary<Type, DeclaredType>();
            var subclasses = GetAllSubclassOf(typeof(IType));   
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
                        if (_declares.ContainsKey(lower))
                        {
                            throw new DuplicateDeclareException();
                            //$"<color=red>{declaredType.Type.GetType().Namespace+"."+ declaredType.Type.GetType().Name}</color>"
                            // +$" Declare Duplicated Exception :: Already Used Declare Keyword <color=yellow>{declamation}</color> " + $"in {this.declares[lower].Type.GetType().Name}");
                        }
                        else
                        {
                            _declares[lower] = declaredType;
                            _declaresWithType[declaredType.BaseType] = declaredType;
                        }
                    }
                }
                // 이.. 이넘을.. 어떻게하지..? 쓉..!!
                if (type.IsEnum)
                {
                    var typeReader = Activator.CreateInstance(type);
                    var declaredType = new DeclaredType(typeReader as IType);
                    var declareKeywords = declaredType.GetDeclares().Distinct();
                    
                }
            }
        }
    }
}
