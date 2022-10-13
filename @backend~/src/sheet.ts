namespace Sheet {
  export const openSheet = (spreadSheetId: Id, sheetId: Id) => {};

  export const open = (id: Id) => {
    const spreadSheet = SpreadsheetApp.openById(id);
    const sheets = spreadSheet.getSheets();
    return { spreadSheet, sheets };
  };

  export const toJson = () => {};
}
