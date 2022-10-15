 
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
        var imguiCointainer = this.rootVisualElement.parent.Query<IMGUIContainer>().Build().First();
        imguiCointainer.RemoveFromHierarchy();
        this.rootVisualElement.parent.RemoveFromHierarchy();
        this.rootVisualElement.parent.style.backgroundColor = new StyleColor(new Color(255,255,255)); 
        var asset = EditorAsset.Load<VisualTreeAsset>("GUI/View/UGSWindow.uxml");  
        var style = EditorAsset.Load<StyleSheet>("GUI/View/UGSWindow.uss");
        asset.CloneTree(rootVisualElement);
        rootVisualElement.RegisterCallback<KeyUpEvent>(OnKeyDown, TrickleDown.TrickleDown);
        this.rootVisualElement.RegisterCallback<PointerDownEvent>(callback =>
        {
            DragAndDrop.StartDrag("start drag");
        });
        this.rootVisualElement.RegisterCallback<PointerUpEvent>(callback =>
        {
           
        });
        this.rootVisualElement.RegisterCallback<PointerMoveEvent>(callback =>
        {


        });
        this.rootVisualElement.RegisterCallback<DragUpdatedEvent>(callback =>
        {
            Debug.Log("A");

        });
        this.rootVisualElement.RegisterCallback<DragEnterEvent>(callback =>
        {
            Debug.Log("callback!");
            EditorWindow wnd = GetWindow<UGSMainWindow>();
            wnd.position = new Rect(callback.mousePosition.x, wnd.position.y, wnd.position.width, wnd.position.y);

        });
        this.rootVisualElement.RegisterCallback<DragExitedEvent>(callback =>
        {
            Debug.Log("callback!");
            EditorWindow wnd = GetWindow<UGSMainWindow>();
            wnd.position = new Rect(callback.mousePosition.x, wnd.position.y, wnd.position.width, wnd.position.y);

        }); 

    }
}