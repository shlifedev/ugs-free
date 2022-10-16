using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeDev.UIElementsExtension;
using UnityEngine;
using UnityEngine.UIElements;

namespace UGS.Editor
{
    public class Window : ElementTreeAssetBase<VisualElement>
    {
        [UQuery("window-pwd-container")]
        public VisualElement PwdContainer;
        public override string ComponentPath => "GUI/View/Components/";

        public Window(VisualElement target) : base(target)
        { 
           
        } 
    }
}
