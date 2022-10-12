using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core;


namespace UGS.Runtime
{ 
    internal class FakeSheetSchema : ISheetSchema<GeneralDataDictionary>
    {
        public FakeSheetSchema()
        {

        }
        public string Id { get; set; }
        public SpreadSheetData SheetData { get; set; }
        public List<GeneralDataDictionary> List { get; set; }
        public NumberableDictionary<GeneralDataDictionary> Dictionary { get; set; }

        public void Load(string src)
        {
            throw new NotImplementedException();
        }

        public void LoadFromGoogle(string src)
        {
            throw new NotImplementedException();
            var a = new System.Object(); 
        }

        public void Save(string src)
        {
            throw new NotImplementedException();
        }
    }
}
