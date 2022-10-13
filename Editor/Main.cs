using UnityEditor;
using UnityEngine;

namespace UGS.Editor
{
    public class Main : MonoBehaviour
    {
        private void Awake()
        {
            var loaded = AssetDatabase.LoadAssetAtPath<GameObject>(
                "Packages/com.shlifedev.ugs/Runtime/Resources/ElementAssetReference.prefab");

            Debug.Log(loaded);
        }
    }
}