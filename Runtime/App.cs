using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core;
using UnityEngine;

namespace UGS.Runtime{

    public class App : MonoBehaviour
    {
        public void Awake()
        {
            new TypeMap().Read();
        }
    }
}
