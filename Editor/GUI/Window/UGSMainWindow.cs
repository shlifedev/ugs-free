 
using UGS.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UGSMainWindow : EditorWindow
{
    [MenuItem("Tools/My Custom Editor")]
    public static void ShowMyEditor()
    { 
        EditorWindow wnd = GetWindow<UGSMainWindow>();
        wnd.titleContent = new GUIContent("My Custom Editor");
    }
    class Base<T>
    { 
        public T somesomething;
    } 
    public void CreateGUI()
    {
        var asset = EditorAsset.Load<VisualTreeAsset>("GUI/View/UGSWindow.uxml"); 
        var style = EditorAsset.Load<StyleSheet>("GUI/View/UGSWindow.uss");
        asset.CloneTree(rootVisualElement);   
    }
}