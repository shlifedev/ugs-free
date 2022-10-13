namespace UGS.Runtime.Core.Validator
{
    internal class RowCountValidation : ISpreadSheetDataValidator
    {
        /// <summary>
        ///     첫 컬럼과 나머지 컬럼의 벨류 길이가 같은경우 OK
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Valid(SpreadSheetData data)
        {
            if (data.Columns.Count > 0)
            {
                var firstColumn = data.Columns[0];
                var diffCheck = data.Columns.Find(x => x.Values.Length != firstColumn.Values.Length);
                return diffCheck == null;
            }

            return false;
        }
    }
}