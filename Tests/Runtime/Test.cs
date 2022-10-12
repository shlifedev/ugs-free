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
            UniGoogleSheets.Initialize(UniGoogleSheets.ECodeGen.Both);
            var a =   UniGoogleSheets.Utility.Read<int>("10000");
            var b = UniGoogleSheets.Utility.Read<int>("20000");

            var json =  JsonUtility.ToJson(new SpreadSheetData()
            {
                Meta = new Metadata()
                {
                    FileName = "Item",
                    Namespace = "Game"
                },
                Columns = new List<Colum>()
                {
                    new Colum("a", "int", new string[] {"1","2"}),
                    new Colum("b", "int", new string[] {"1","2"}),
                    new Colum("c", "int", new string[] {"1","2"}),
                }, 
            });

            Debug.Log(json);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
