using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Editor;
using UnityEngine.UIElements;

namespace Packages.ugs_free.Editor.GUI.View.Components
{
    internal class Window : ElementTreeAssetBase<VisualElement>
    {
        public override string ComponentPath => "GUI/View/Components/";

        public Window(VisualElement target) : base(target)
        {
        }
    }
}
