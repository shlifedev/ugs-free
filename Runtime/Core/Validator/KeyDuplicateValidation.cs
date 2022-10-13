using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGS.Runtime.Core.Validator
{
    internal class KeyDuplicateValidation : ISpreadSheetDataValidator
    {
        /// <summary>
        /// 키는 string 혹은 int 타입이어야만 합니다. 
        /// </summary> 
        public bool Valid(SpreadSheetData data)
        {
            var distincted = data.Columns.First().Values.ToList().Distinct().Count();
            return distincted == data.Columns.First().Values.Length;
        }
    }
}
