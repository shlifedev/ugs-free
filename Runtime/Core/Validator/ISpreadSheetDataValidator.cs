﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGS.Runtime.Core.Validator
{
    internal interface ISpreadSheetDataValidator
    {
         bool Valid(SpreadSheetData data);
    }
}
