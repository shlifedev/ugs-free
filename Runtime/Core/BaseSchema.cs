﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PlasticPipe.Server;
using UGS.Runtime.Core;
using UnityEngine;

namespace UGS.Runtime.Core
{
     
    public class BaseSchema<Model> where Model : class
    { 
        private static SpreadSheetData _sheetData; 
        public void Bind(SpreadSheetData @value)
        {
            Debug.Log("called");
            List = new List<Model>();
            Dictionary = new NumberableDictionary<Model>();
            SheetData = @value;
            var values = @value.Columns.First().Values.Length;
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
                        (@value.Columns[c].Type, @value.Columns[c].Values[r])); 
                
                }

                List.Add(model);
                Dictionary.Add(keys[r], model);  
            } 
        }
        public static SpreadSheetData SheetData
        {
            get => _sheetData;
            set
            {
                //Bind(value);
                _sheetData = value;
      
            }
        }


        public static List<Model> List { get; set; }
        public static NumberableDictionary<Model> Dictionary { get; set; }
    }
}