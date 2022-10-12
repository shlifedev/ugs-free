using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UGS.Runtime
{
    [System.Serializable]
    public class ElementAsset
    {
        public string Key;
        public VisualTreeAsset ElementTree;
    }

    public class ElementAssetReference : MonoBehaviour
    {
        public List<ElementAsset> assetReferences;
        public VisualTreeAsset Get(string key) => assetReferences.Find(x => x.Key == key)?.ElementTree;
    }
      
}