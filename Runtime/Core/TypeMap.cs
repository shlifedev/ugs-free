using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core.Interfaces;
using UGS.Runtime.Types;

namespace UGS.Runtime.Core
{
    public class DeclaredType
    {
        public DeclaredType(IType type)
        {
            this.type = type;
        }
        public IType type;

        public bool IsEnum()
        {
            var generics = type.GetType().GenericTypeArguments;
            if (generics == null || generics.Length == 0) throw new Exception("CanNot Found Generic of IType");
            return generics[0].IsEnum;
        }
    } 
    public class TypeMap
    { 
        public Dictionary<string, IType> declares = new Dictionary<string, IType>(); 
        public void Read()
        {
            var subclasses = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(IType))
                select type;

            foreach (var type in subclasses)
            {
                if (type.IsInterface) continue; 
                var typeReader = Activator.CreateInstance(type);
                var read = type.GetMethod("Read");
                var wrtie = type.GetMethod("Write"); 
            } 
        }
    }
}
