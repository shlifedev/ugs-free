using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGS.Runtime.Core.Interfaces
{
    public interface IType
    {
    }

    public interface IType<T> : IType
    {
        /// <summary>
        /// All Type Names Auto Convert To Lower. (Int => int), (iNT => int)
        /// </summary>
        public List<string> TypeDeclarations { get; }

        public T Read(string value);

        public string Write(T value);
    }
}
