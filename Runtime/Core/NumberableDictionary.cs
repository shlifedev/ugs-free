using System.Collections.Generic;

namespace UGS.Runtime.Core
{
    public class NumberableDictionary<T> : Dictionary<string, T>
    {
        public T this[int key]
        {
            get
            {
                return this[key.ToString()];
            }
            set
            {
                this[key] = value;
            }
        }
    }
}