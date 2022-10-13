using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class UGSWIndow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/UGSWIndow")]
    public static void ShowExample()
    {
        UGSWIndow wnd = GetWindow<UGSWIndow>();
        wnd.titleContent = new GUIContent("UGSWIndow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement; 
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/com.shlifedev.ugs/Runtime/View/UGSWIndow.uxml"); 
        var clone = visualTree.CloneTree().contentContainer; 
 
        root.Add(clone);
    }
}