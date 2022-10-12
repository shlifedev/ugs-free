using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core;
using UnityEngine;

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

    interface ISchema<T> 
    where T : class
    {
        public SpreadSheetData SheetData { get; set; }
        public List<T> List { get; set; }
        public NumberableDictionary<T> Dictionary { get; set; } 
        public string FileName { get; set; }
        void Load(string src);
        void LoadFromGoogle(string src);
        void Save(string src);
    } 

     
    /// <summary>
    /// For Without Code Generator
    /// </summary>
    internal class PureDatabase
    {
        public List<ISchema> spreadSheets; 
        public void Initialize()
        {
             
        }
    }
}
