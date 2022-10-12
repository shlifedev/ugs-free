using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace UGS.Runtime.Core
{
    [System.Serializable]
    public record SpreadSheetData
    { 
        public Metadata Meta;
        public List<Colum> Columns;
    }

    [System.Serializable]
    public record Metadata
    {  
        public string Namespace;
        public string FileName; 
    } 
    [System.Serializable]
    public record Colum
    {
        public string Name;
        public string Type;
        public string[] Values;

        public Colum(string name, string type, string[] values)
        {
            this.Name = name;
            this.Type = type;
            this.Values = values;
        }
    } 
    public class Test
    {
        void Sample()
        {
            
        }
    }
}
 