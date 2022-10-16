using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements;

namespace UGS.Editor
{
    /// <summary>
    /// template container 
    /// </summary>
    public abstract class ElementTreeAssetBase
    {
        protected VisualTreeAsset _cached;
        protected VisualElement _root;
        public static System.Action<VisualElement> callback;
        public static void RegisterInstantiateCallback(System.Action<VisualElement> callback)
        {
            callback += callback;
        }
         
        protected virtual void OnInstantiated()
        {

        }

        public ElementTreeAssetBase()
        {
            Load();
            _root = Instantiate();
        }

        public abstract string UXMLPath { get; }

        public VisualElement Root => _root;
        VisualTreeAsset Load()
        {
            if (_cached == null)
                _cached = EditorAsset.Load<VisualTreeAsset>(UXMLPath);

            if (_cached == null) throw new Exception($"Not found element. {UXMLPath}");
            return _cached;
        }

        private VisualElement Instantiate()
        {
            if (_root == null)
            {
                var instance = _cached.CloneTree(); 
                callback?.Invoke(instance);
                OnInstantiated();
                if (instance.Children().Count() != 0)
                {
                    var children = instance.Children().First();
                    if (children.GetClasses().Any(x => x == "root"))
                    {
                        return children;
                    } 
                }

                return instance;
            }
            return _root;
        }
    }
}