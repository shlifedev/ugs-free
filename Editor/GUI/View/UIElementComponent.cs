using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Codice.CM.Common;
using UGS.Editor;
using UnityEngine;
using UnityEngine.UIElements; 

namespace LifeDev.UIElementsExtension
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class UQueryAttribute : System.Attribute
    {
        public readonly string Name;
        public readonly string[] Classes;

        public UQueryAttribute(string name = null, params string[] classes)
        {
            Name = name;
            Classes = classes;
        }
    }
    public abstract class UIElementComponent<T> where T : VisualElement
    {
        private delegate void CloneTreeDelegate<T0, T1, T2>(T0 target, out T1 a, out T2 b) where T0 : VisualElement;

        private static CloneTreeDelegate<VisualElement, int, int> CloneTreeWithIndex { get; set; }
        private static System.Func<VisualElement, VisualElement> CloneTree { get; set; }

        private static VisualTreeAsset _cached;
        private StyleSheet _cachedStyle;
        private T _root;

        //public VisualElement Parent => Root.parent;
        //public IStyle Style => Root.style;
        //public VisualElementStyleSheetSet StyleSheets => Root.styleSheets;
        //public string Name => Root.name; 
        public UIElementComponent(T target)
        {
            Initialize();
            var cloned = CloneTree(target) as T;
            _root = cloned;

            var fields = this.GetType().GetFields()
                .Where(x => x.GetCustomAttribute(typeof(UQueryAttribute), false) != null);
            fields.ToList().ForEach(field =>
            {
                var queryableMeta = field.GetCustomAttribute(typeof(UQueryAttribute)) as UQueryAttribute;
                var queried = this.Root.parent.Query(queryableMeta.Name, queryableMeta.Classes).First(); 
                if (queried != null) 
                    field.SetValue(this, queried); 
            });


        }
         

        public abstract string ComponentPath { get; }
        public string ComponentFilePath => Path.GetDirectoryName(ComponentPath) +"/"+ this.GetType().Name;

        public T Root => _root;  
        void Initialize()
        {
            if (_cached == null)
                _cached = EditorAsset.Load<VisualTreeAsset>(string.Concat(ComponentFilePath, ".uxml"));

            if (_cached == null) throw new Exception($"Can't Initialize UIElementComponent => Cannot Found {ComponentFilePath}.uxml");
            CloneTreeWithIndex = _cached.CloneTree; 
            CloneTree = (target) =>
            {
                int firstElementIndex, added = 0; 
                CloneTreeWithIndex(target, out firstElementIndex, out added);
                var content = target.Children().TakeLast(added).First();
                _root = content as T;
                return content;
            };
        }


         
    }
}