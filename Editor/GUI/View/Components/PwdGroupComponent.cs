using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace UGS.Editor
{
    public class PwdGroupComponent : VisualElement
    {
        public Label pwdLabel;
        public PwdGroupComponent(string text)
        {
            
        }

        public new class Traits : UxmlTraits
        {

        }
    }
}
