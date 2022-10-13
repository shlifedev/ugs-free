using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UGSMainWindow : EditorWindow
{ 
    [MenuItem("Tools/My Custom Editor")]
    public static void ShowMyEditor()
    {
        Debug.Log("Run editor window!");
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<UGSMainWindow>();
        wnd.titleContent = new GUIContent("My Custom Editor");
    }

    public void CreateGUI()
    {
        var asset = Resources.Load<VisualTreeAsset>("@ugs-ui/Window"); 
        var style = Resources.Load<StyleSheet>("@ugs-ui/WindowUSS"); 
        var clone = asset.CloneTree(); 
        rootVisualElement.Add(clone);
        clone.styleSheets.Add(style);
    }
}