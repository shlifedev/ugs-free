using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UGS.Runtime;
using UGS.Runtime.Core;
using UnityEngine;

namespace UGS.Test
{
    public class Test : MonoBehaviour
    {
        void Start()
        {
            UniGoogleSheets.Initialize(CodegenOption.Both);
            Game.Item.List.ForEach(x =>
            {
                Debug.Log(x.id + "," + x.name);
            });




            SpreadSheetData data = new SpreadSheetData()
            {
                Meta = new Metadata("1293129321", "Game", "Item"),
                Columns = new List<Colum>()
                {
                    {
                        new Colum("hi", "int", new string[] {"a", "b"})
                    }
                }
            };

        }
    }
}
