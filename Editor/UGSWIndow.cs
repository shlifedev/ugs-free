using UnityEditor; 
using UnityEngine;
using UnityEngine.UIElements; 

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
        var visualTree = Resources.LoadAll<VisualTreeAsset>("@ugs-views/");
        foreach(var print in visualTree)
        {
            root.Add(new Label(""));
            print.CloneTree(root); 
        } 
    }
}