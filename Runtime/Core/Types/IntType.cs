using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core.Interfaces;
using UnityEngine;

namespace UGS.Runtime.Types
{ 
    public class IntType : IType<int>
    {
        public List<string> TypeDeclarations => new List<string>()
        {
            "Int",
            "Integer"
        };


        public int Read(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch(Exception err)
            {
                Debug.LogError($"Failed to parse data => {value}");
                throw err;
            }
        }

        public string Write(int value)
        {
            return value.ToString();
        }
    }
}
