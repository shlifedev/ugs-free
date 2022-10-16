//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UGS.Editor;
//using UnityEngine.UIElements;

//namespace Packages.ugs_free.Editor.GUI.View.Components
//{
//    internal abstract class BaseComponent : VisualElement
//    {
//        public abstract string ComponentPath { get; }
//        protected VisualElement _cached;   
//        public BaseComponent()
//        {
//            Load();
//        }
//        void Load()
//        { 
//            if (_cached == null)
//                _cached = EditorAsset.Load<VisualTreeAsset>(string.Concat(ComponentPath, ".uxml"));

//            if (_cached == null) throw new Exception($"Not found element. {ComponentPath}"); 
//        }

//    }
//}
