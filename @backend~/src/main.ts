
function test(){
  const response = doPost({
    parameter : {
      params : {},
      option : {}
    }
  })

  log(JSON.stringify(response));
}  
function testContext(){
  var context = Sheet.getContext("10_CFs1W-uF7ETsrhrmpVX_j4QQMKA7f5gNtLiU3-VU0");
  log(JSON.stringify(context.datas));  
  log(context.indexOf(String(2009728146), 5001));
}
function post(e: any) : IResponse{
  const {params, option} = e.parameter; 
  const action = params.action as RequestAction;
  
  var password = PropertiesService.getScriptProperties().getProperty("password");
  if(password){
    if(option.password !== params) return {
      Code : ServerCode.WrongPassword,
      Data : null,
      Message : option.password ? "Wrong Password." :  "If you defined scriptProperties (password) then [parameter.option.password] must be required."
    }   
  }
  try{ 
  if(action){
    if(action === "get-DriveFiles") {  
      var context = Sheet.getContext(params.payload.Id as Id);
      return { 
        Code : ServerCode.Success,
        Data : JSON.stringify(context.datas),
        Message : `Succesfully Generated JSON`
      }
    } 
    return {
      Code : ServerCode.Error,
      Data : null,
      Message : `${action} action not found`
    }
  }
  else{
    return {
      Code : ServerCode.Error,
      Data : null,
      Message : "Require Action"
    }
  }
  }
  catch(err : any){ 
    return {
      Code : ServerCode.Exceped,
      Data : null,
      Message : JSON.stringify(err)
    }
  }
}

function doPost(e : any){
  return ContentService.createTextOutput(JSON.stringify(post(e)));
}
function doGet(e : any){
    return ContentService.createTextOutput("use doPost(e)");
}
