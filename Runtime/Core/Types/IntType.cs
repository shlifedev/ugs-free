﻿using System;
using System.Collections.Generic;
using UGS.Runtime.Core.Interfaces;
using UnityEngine;

namespace UGS.Runtime.Core.Types
{
    internal class IntType : IType<int>
    {
        public List<string> TypeDeclarations => new()
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
            catch (Exception err)
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