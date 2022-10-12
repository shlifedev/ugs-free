using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core;

namespace UGS.Test
{
    public class BaseSheetSchema<Model> : ISheetSchema<Model> where Model : class
    {
        private SpreadSheetData _sheetData;

        public BaseSheetSchema(string Id, SpreadSheetData data)
        {
            this.List = new List<Model>();
            this.Dictionary = new NumberableDictionary<Model>();
            this.Id = Id;
        }

        public string Id { get; set; }

        public SpreadSheetData SheetData
        {
            get => _sheetData;
            set
            {
                _sheetData = value;
                foreach (var column in _sheetData.Columns)
                {
                    var name = column.Name;
                    var declareType = column.Type;
                    var type = UGS.Runtime.UniGoogleSheets.Utility.DeclareToType(declareType);
                    var keys = UGS.Runtime.UniGoogleSheets.Utility.KeysOf(_sheetData);
                    int index = 0;
                    foreach (var _value in column.Values)
                    {
                 
                        var model = Activator.CreateInstance<Model>();
                        var modelRef = model.GetType();

                        var field = modelRef.GetField(column.Name);
                            field.SetValue(model, UGS.Runtime.UniGoogleSheets.Utility.Read<object>(_value));

                        this.List.Add(model);
                        this.Dictionary.Add(keys[index], model);
                        index++;
                    }
                }
            }
        }


        public List<Model> List { get; }
        public NumberableDictionary<Model> Dictionary { get; }
    }
}
