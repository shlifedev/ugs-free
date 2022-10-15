using UnityEngine.UIElements;
using UnityEngine.UIElements;

namespace UGS.Editor
{
    public abstract class ElementTreeAssetBase
    {
        private static VisualTreeAsset _cached;
        private TemplateContainer _root;
        public static System.Action<TemplateContainer> callback;
        public static void RegisterInstantiateCallback(System.Action<TemplateContainer> callback)
        {
            callback += callback;
        }

        public abstract string UXMLPath { get; } 
        VisualTreeAsset Load()
        {
            if (_cached == null)
                _cached = EditorAsset.Load<VisualTreeAsset>(UXMLPath);
            return _cached;
        }

        public TemplateContainer Instantiate()
        {
            if (_root == null)
            {
                var instance = EditorAsset.Load<VisualTreeAsset>(UXMLPath).Instantiate();
                callback?.Invoke(instance);
                return instance;
            } 
            return _root; 
        }
    }
}