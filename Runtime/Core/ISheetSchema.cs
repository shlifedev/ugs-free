using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace UGS.Runtime.Core
{
    public interface ISheetSchema
    {
    }

    public interface ISheetSchema<T> : ISheetSchema
        where T : class
    {
        public string Id { get; set; }
        public SpreadSheetData SheetData { get; set; }
        public List<T> List { get; }
        public NumberableDictionary<T> Dictionary { get;}   
    }

    public interface ISchemaLoader<T>
    {
        void Load(string src);
        void LoadFromGoogle(string src);
        void Save(string src);
    }
    public class UnitySchemaLoader<T> : ISchemaLoader<T>
    where T : class
    {
        private readonly ISheetSchema<T> _schema;

        public UnitySchemaLoader(ISheetSchema<T> schema)
        {
            _schema = schema;
        }
        public void Load(string src)
        {
            var asset = Resources.Load<TextAsset>(src);
            if (asset != null)
            {
               
            }
            else
            {
                throw new Exception($"Resources 폴더 안에서 {src} 경로에서 파일을 찾을 수 없습니다.");
            }
        }

        public void LoadFromGoogle(string src)
        {
            throw new System.NotImplementedException();
        }

        public void Save(string src)
        {
            throw new System.NotImplementedException();
        }
    }
}