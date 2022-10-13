
type DriveFileType = "spreadsheet" | "directory" | "unknown"
type Id = string;

interface IMetadata{
  FileName : string,
  GId : Id,
  Namespace : string
}

interface IColumn{
  Name : string ,
  Type : string ,
  Values : string[] 
}

interface ISpreadSheetData {
  Id : Id
  Namespace : string,
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
enum ServerCode {
  Success,
  Error,
  Exceped
}

interface IResponse{
  code : ServerCode,
  message : string,
  data : any
}