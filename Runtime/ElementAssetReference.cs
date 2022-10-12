using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[System.Serializable]
public class ElementAsset
{
    public string Key;
    public VisualTreeAsset ElementTree;
}
public class ElementAssetReference : MonoBehaviour
{
    public List<ElementAsset> assetReferences;
}
