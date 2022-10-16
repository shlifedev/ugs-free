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
    public class PwdGroup : UIElementComponent<VisualElement>
    {
        public struct Context
        {
            public string SheetId;

            public Context(string SheetId)
            {
                this.SheetId = SheetId;
            }
        }
        [UQuery("pwd-icon")]
        public Image Icon;
        [UQuery("pwd-text")]
        public Label label;
        public override string ComponentPath => "GUI/View/Components/";

        public PwdGroup(VisualElement target, Context context) : base(target)
        { 
            
        }
    }
}