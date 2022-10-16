 
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
    void OnKeyDown(KeyUpEvent ev)
    {
        Debug.Log("KeyDown:" + ev.keyCode);
        Debug.Log("KeyDown:" + ev.character);
        Debug.Log("KeyDown:" + ev.modifiers);
    }
    public void CreateGUI()
    {
        var window = new UGSWindow(); 
        rootVisualElement.Add(window.Root.contentContainer);
        for(int i =0; i < 4; i++)
        {

            var pwdGroup = new PwdGroup();
            rootVisualElement.Query(null, "pwd-wrap").First().Add(pwdGroup.Root);
        }
         
    }
} 