using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGS.Runtime.Core.Types
{
    internal class StringType : IType<string>
    {
        public List<string> TypeDeclarations => new List<string>() { "String", "Text" };

        public string Read(string value)
        {
            try
            {
                return value;
            }
            catch
            {
                Debug.LogError($"Failed to parse data => {value}");
                return null;
            }
        }

        public string Write(string value)
        {
            return value;
        }
    }
}