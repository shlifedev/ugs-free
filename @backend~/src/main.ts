 

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
  
  var password = PropertiesService.getScriptProperties().getProperty("password");
  if(password){
    if(option.password !== params) return {
      code : ServerCode.WrongPassword,
      data : null,
      message : option.password ? "Wrong Password." :  "If you defined scriptProperties (password) then [parameter.option.password] must be required."
    }
  }
  try{ 
  if(action){
    if(action === "get-DriveFiles") { 
      var datas = Sheet.toSpreadSheetDatas(params.payload.Id as Id);
      return {
        code : ServerCode.Success,
        data : JSON.stringify(datas),
        message : `Succesfully Generated JSON`
      }
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
