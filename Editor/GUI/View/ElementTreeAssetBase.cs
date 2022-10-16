using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements; 

namespace UGS.Editor
{
    /// <summary>
    /// template container 
    /// </summary>
    public abstract class ElementTreeAssetBase<T> where T : VisualElement
    {
        public delegate void CloneTreeDelegate<T0, T1, T2>(T0 target, out T1 a, out T2 b) where T0 : VisualElement;

        private static CloneTreeDelegate<VisualElement, int, int> CloneTreeWithIndex { get; set; }
        private static System.Func<VisualElement, VisualElement> CloneTree { get; set; }

        protected static VisualTreeAsset _cached;
        private StyleSheet _cachedStyle;
        private T _root;
        public static System.Action<VisualElement> callback;
        public static void RegisterInstantiateCallback(System.Action<VisualElement> callback)
        {
            callback += callback;
        }
         
        protected virtual void OnInstantiated()
        {

        }

        public ElementTreeAssetBase(T target)
        {
            Initialize();
            var ve = CloneTree(target) as T;
            _root = ve;
        }
         

        public abstract string ComponentPath { get; }
        public string ComponentFilePath => Path.GetDirectoryName(ComponentPath) +"/"+ this.GetType().Name;

        public T Root => _root;  
        void Initialize()
        {
            if (_cached == null)
                _cached = EditorAsset.Load<VisualTreeAsset>(string.Concat(ComponentFilePath, ".uxml"));

            if (_cached == null) throw new Exception($"Can't Initialize ElementTreeAssetBase => Cannot Found {ComponentFilePath}.uxml");
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