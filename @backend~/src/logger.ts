const disable = false; 
function log (log: any) {
  if (disable) return;
  return Logger.log(`[UniGoogleSheets] ${log}`);
}; 