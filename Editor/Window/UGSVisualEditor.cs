using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UGSVIsualEditor : EditorWindow
{ 
    [MenuItem("Tools/My Custom Editor")]
    public static void ShowMyEditor()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<UGSVIsualEditor>();
        wnd.titleContent = new GUIContent("My Custom Editor");
    }

    public void CreateGUI()
    {
        var asset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/com.shlifedev.ugs/Editor/View/UGSVisualEditor.uxml");
 
        rootVisualElement.Add(asset.CloneTree()); 
    }
}