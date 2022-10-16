using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Editor;
using UnityEngine.UIElements;

namespace UGS.Editor
{
    internal class Window : ElementTreeAssetBase<VisualElement>
    {
        public override string ComponentPath => "GUI/View/Components/";

        public Window(VisualElement target) : base(target)
        {
        } 
    }
}
