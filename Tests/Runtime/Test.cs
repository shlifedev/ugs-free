using System.Collections;
using System.Collections.Generic;
using UGS.Runtime;
using UnityEngine;

namespace UGS.Test
{
    public class Test : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        { 
            UniGoogleSheets.Initialize();
            var a =   UniGoogleSheets.Utility.Read<int>("10000");
            var b = UniGoogleSheets.Utility.Read<int>("20000");

            Debug.Log(a);
            Debug.Log(b);

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
