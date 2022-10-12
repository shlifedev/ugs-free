using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGS.Runtime.Core.Validator
{
    internal class KeyValidation : ISpreadSheetDataValidator
    {
        /// <summary>
        /// 키는 string 혹은 int 타입이어야만 합니다. 
        /// </summary> 
        public bool Valid(SpreadSheetData data)
        {
            var typeChecker = new TypeMap();  
           
            if (data.Columns.Count == 0)
                throw new Exception("데이터 내에서 어떠한 컬럼도 찾을 수 없습니다.");
           
            var type = typeChecker[data.Columns[0].Type];
          
            if (type.BaseType == typeof(int)
                || type.BaseType == typeof(string))
                return true;

            return false;
        }
    }
}
