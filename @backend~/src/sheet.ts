type SpreadSheet = GoogleAppsScript.Spreadsheet.Spreadsheet;
namespace Sheet {  
   
  export const open = (id: Id) => {
    const spreadSheet = SpreadsheetApp.openById(id); 
    return spreadSheet;
  };
   
  export const getContext = (id: Id) => {
    const spreadSheet = Sheet.open(id);  
     
    const getDatas = (): ISpreadSheetData[] => {
      const app = spreadSheet;
      const appName = app.getName();
      const datas: ISpreadSheetData[] = []; 
      const sheets = app.getSheets().forEach((s) => {
        const meta: IMetadata = {
          Namespace: appName,
          FileName: s.getName(),
          GId: String(s.getSheetId()),
        };

        const lastRow = s.getLastRow();
        const lastColumn = s.getLastColumn();
        const ranges = s.getRange(1, 1, lastRow, lastColumn).getValues();
        const columns: IColumn[] = [];

        /* read */
        for (let col = 0; col < lastColumn; col++) {
          const [name, type] = (ranges[0][col] as string).trim().split(":");
          const desc = ranges[1][col] as string;
          const columnValues = [];
          for (let row = 2; row < lastRow; row++) {
            columnValues.push(ranges[row][col]);
          }
          columns.push({
            Name: name,
            Type: type,
            Values: columnValues,
          });
        }

        datas.push({
          Id: app.getId(),
          Meta: meta,
          Namespace: appName,
          Columns: columns,
        });
      });
 
      return datas;
    };  
    const datas = getDatas();
    const indexOf = (gid : Id, key: string | number) => {
      return datas.find(x=>x.Meta.GId == gid).Columns[0].Values.indexOf(key as string);
    };
    const indexOfByName = (name : string, key: string) => {
      return datas.find(x=>x.Meta.FileName == name).Columns[0].Values.indexOf(key);
    }; 
 
    return {
      spreadSheet, 
      getDatas,
      datas,
      indexOf,indexOfByName
    };
  };
}

