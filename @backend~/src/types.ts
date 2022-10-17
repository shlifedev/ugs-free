
type DriveFileType = "spreadsheet" | "directory" | "unknown"
type Id = string;
type RequestAction =
 "convert-SpreadSheet" | 
 "create-Row" | 
 "update-Row" | 
 "create-Template" | 
 "get-DriveFiles" 

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
  WrongPassword,
  Exceped
}

interface IResponse{
  Code : ServerCode,
  Message : string,
  Data : any
}