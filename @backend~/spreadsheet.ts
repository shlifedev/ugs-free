
interface IMetadata{
  FileName : string,
  Id : string,
  Namespace : string
}

interface IColumn{
  Name : string ,
  Type : string ,
  Values : string[]
}

interface SpreadSheetData {
  Meta : IMetadata,
  Columns : IColumn[]
}

export const toSheetData = ()=>{}