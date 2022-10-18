using System;
using System.Collections.Generic;
using UGS.Runtime.Core.Attributes;

namespace UGS.Runtime.Core
{
  /// <summary>
  /// code gen 된 클래스들을 깔끔하게 관리하기 위해 (최대한 필드 자동생성을 하지않기위해) 베이스 스키마에 구현을 하고
  /// 기존 스키마는 Static 공간만 상속을통해 위임받는다.
  /// </summary>
  /// <typeparam name="Model"></typeparam>

  public class BaseSchema<Model> where Model : class
  {

    private static Dictionary<System.Type, SpreadSheetData> _sheetData;

    [ReflectInject]
    private static void Bind(SpreadSheetData @value)
    {
      Dictionary<Type, SpreadSheetData> dictionary = new Dictionary<Type, SpreadSheetData>();
      _sheetData = dictionary;
      _sheetData[typeof(Model)] = @value;
      List = new List<Model>();
      Dictionary = new NumberableDictionary<Model>();
      var values = @value.Columns[0].Values.Length;
      var columLength = @value.Columns.Count;
      var keys = UGS.Runtime.UniGoogleSheets.Utility.KeysOf(@value);
      for (int r = 0; r < values; r++)
      {

        var model = Activator.CreateInstance<Model>();
        for (int c = 0; c < columLength; c++)
        {
          var currentField = @value.Columns[c].Values[r];
          var modelRef = model.GetType();
          var field = modelRef.GetField(@value.Columns[c].Name);
          field.SetValue(model, UGS.Runtime.UniGoogleSheets.Utility.Read
              (@value.Columns[c].Type, currentField));

        }

        List.Add(model);
        Dictionary.Add(keys[r], model);
      }
    }
    public static SpreadSheetData SheetData
    {
      get
      {
        var type = typeof(Model);
        if (_sheetData.ContainsKey(type))
        {
          return _sheetData[typeof(Model)];
        }
        else
        {
          throw new Exception("SheetData Is Not Initialized. Use 'UniGoogleSheet.Initialize'");
        }
      }
    }


    public static List<Model> List { get; set; }
    public static NumberableDictionary<Model> Dictionary { get; set; }
  }
}