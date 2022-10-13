using System;
using System.Collections.Generic;

namespace UGS.Runtime.Core
{
    [Serializable]
    public class SpreadSheetData
    {
        public List<Colum> Columns;
        public Metadata Meta;
    }

    [Serializable]
    public class Metadata
    {
        public string FileName;
        public string Id;
        public string Namespace;

        public Metadata(string id, string ns, string fileName)
        {
            Id = id;
            Namespace = ns;
            FileName = fileName;
        }
    }

    [Serializable]
    public class Colum
    {
        public string Name;
        public string Type;
        public string[] Values;

        public Colum(string name, string type, string[] values)
        {
            Name = name;
            Type = type;
            Values = values;
        }
    }
}