using UnityEditor;
using UnityEngine.UIElements;


namespace LifeDev.UIElementsExtension
{
    public static class EditorAsset
    {
        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            var asset = AssetDatabase.LoadAssetAtPath<T>("Packages/com.shlifedev.ugs/Editor/" + path);
            return asset;
        } 
    }
}
