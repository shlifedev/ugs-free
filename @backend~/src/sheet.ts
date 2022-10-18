type SpreadSheet = GoogleAppsScript.Spreadsheet.Spreadsheet;
namespace Sheet {  
   
  export const open = (id: Id) => {
    const spreadSheet = SpreadsheetApp.openById(id); 
    return spreadSheet;
  };
   
  export const getContext = (id: Id) => {
    const spreadSheet = Sheet.open(id);  
    const _sheets = spreadSheet.getSheets();
     
    const getDatas = (): ISpreadSheetData[] => {
      const app = spreadSheet;
      const appName = app.getName();
      const datas: ISpreadSheetData[] = []; 
      const sheets = _sheets.forEach((s) => {
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
    
    const removeRow = (gid : Id, key : string) => {
      const sheet = _sheets.find(x => String(x.getSheetId()) == gid);
      sheet.deleteRow(indexOf(gid, key) + 1);
    }

    const appendRow = (gid : Id, key : string, value : string[]) => {
      const sheet = _sheets.find(x => String(x.getSheetId()) == gid);
      const has = indexOf(gid, key) !== -1;
      if(!has){ 
        const target = datas.find(x=>x.Meta.GId === gid);
        if(target === null) throw new Error(`${gid} not found in datas`); 
        if(value.length == datas.find(x=>x.Meta.GId === gid).Columns.length)
           sheet.appendRow(value)
        else throw new Error("전달 받은 열의 길이와 시트가 구성하고있는 열의 길이가 다릅니다. 이 문제를 해결하려면 유니티 내에서 Generate를 먼저 호출하십시오.");
      }

    }
 
    return {
      spreadSheet, 
      getDatas,
      datas,
      indexOf,indexOfByName
    };
  };
}

