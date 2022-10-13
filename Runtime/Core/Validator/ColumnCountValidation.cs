using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGS.Runtime.Core.Validator
{
    internal class ColumnCountValidation : ISpreadSheetDataValidator
    { 
        public bool Valid(SpreadSheetData data)
        {
            return data.Columns.First() != null;
        }
    }
}