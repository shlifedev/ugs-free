using System;
using System.Collections.Generic;
using UGS.Runtime.Core.Interfaces;
using UnityEngine;

namespace UGS.Runtime.Core.Types
{
    internal class FloatType : IType<float>
    {
        public List<string> TypeDeclarations => new()
        {
            "Float"
        };


        public float Read(string value)
        {
            try
            {
                return float.Parse(value);
            }
            catch (Exception err)
            {
                Debug.LogError($"Failed to parse data => {value}");
                throw err;
            }
        }

        public string Write(float value)
        {
            return value.ToString();
        }
    }
}