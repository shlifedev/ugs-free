const disable = false; 
function log (log: object | string | number) {
  if (disable) return;
  return console.log(`[UniGoogleSheets] ${log}`);
};