using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace UGS.Runtime.Core
{
    [System.Serializable]
    public class SpreadSheetData
    { 
        public Metadata Meta;
        public List<Colum> Columns;
    }

    [System.Serializable]
    public class Metadata
    {
        public string Id;   
        public string Namespace;
        public string FileName;

        public Metadata(string id, string ns, string fileName)
        {
            Id = id;
            Namespace = ns;
            FileName = fileName;
        }
    } 
    [System.Serializable]
    public class Colum
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
}
 