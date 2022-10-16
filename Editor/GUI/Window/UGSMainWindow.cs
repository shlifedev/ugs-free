  
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

    public void CreateGUI()
    { 
        var window = new Window(this.rootVisualElement);
    }
} 