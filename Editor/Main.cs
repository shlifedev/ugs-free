using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UGS.Editor
{
    public class Main : MonoBehaviour
    {
        void Awake()
        {
            var loaded = AssetDatabase.LoadAssetAtPath<GameObject>(
                "Packages/com.shlifedev.ugs/Runtime/Resources/ElementAssetReference.prefab");

            Debug.Log(loaded);
        }
    }
}
