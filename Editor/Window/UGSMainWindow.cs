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
    class Base<T>
    { 
        public T somesomething;
    } 
    public void CreateGUI()
    {
        var asset = Resources.Load<VisualTreeAsset>("@ugs-ui/Window");
        var style = Resources.Load<StyleSheet>("@ugs-ui/WindowUSS");
        var clone = asset.CloneTree();
        var container = clone.Query("container").First();
        rootVisualElement.Add(container);
        container.styleSheets.Add(style);


        var type = typeof(Base<>);

    }
}