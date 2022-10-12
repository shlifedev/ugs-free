using System.Collections;
using System.Collections.Generic;
using UGS.Runtime;
using UGS.Runtime.Core;
using UnityEngine;

namespace UGS.Test
{
    public class Test : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        { 
            UniGoogleSheets.Initialize(UniGoogleSheets.CodegenOption.Both); 
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
