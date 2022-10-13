type RequestAction = 
"getSpreadSheet"
function myFunction() {
  var datas = Sheet.toSpreadSheetDatas(
    "1dTIFRiACz1b74VZmElXIuRw48I2xj56xtIU6MaKKNlw"
  );
  var json = JSON.stringify(datas);
  log(json);
}

function test(){
  const response = doPost({
    parameter : {
      params : {},
      option : {}
    }
  })

  log(JSON.stringify(response));
}

function doPost(e: any) : IResponse{
  const {params, option} = e.parameter; 
  const action = params.action as RequestAction;
  try{ 
  if(action){
    if(action === "getSpreadSheet") {

    } 
    return {
      code : ServerCode.Error,
      data : null,
      message : `${action} action not found`
    }
  }
  else{
    return {
      code : ServerCode.Error,
      data : null,
      message : "Require Action"
    }
  }
  }
  catch(err : any){ 
    return {
      code : ServerCode.Exceped,
      data : null,
      message : JSON.stringify(err)
    }
  }
}
