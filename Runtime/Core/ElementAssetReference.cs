using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UGS.Runtime
{
    [Serializable]
    internal class ElementAsset
    {
        public VisualTreeAsset ElementTree;
        public string Key;
    }

    internal class ElementAssetReference : MonoBehaviour
    {
        public List<ElementAsset> assetReferences;

        public VisualTreeAsset Get(string key)
        {
            return assetReferences.Find(x => x.Key == key)?.ElementTree;
        }
    }
}