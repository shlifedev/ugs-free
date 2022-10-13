using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGS.Runtime.Core.Types;

namespace UGS.Test
{
    public enum GameState
    { 
        Playing,
        End,
        Something
    }
    
    public class CustomEnum : EnumType<GameState>
    {
        public override List<string> TypeDeclarations => new List<string>(){ "GameState"};
    }

    internal class CustomTypeTest
    {

    }
}
