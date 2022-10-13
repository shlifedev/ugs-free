
type DriveFileType = "spreadsheet" | "directory" | "unknown"
type Id = string;

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

interface IDriveFile{
  Id   : Id
  Type : DriveFileType, 
}
interface IDriveInfo{
  Id : string,
  Files : {}
}