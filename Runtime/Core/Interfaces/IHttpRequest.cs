using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGS.Runtime.Interfaces
{
    public class UGSHttpResponse
    {
        public int ResponseCode;
        public string Message; 
        public UGSHttpResponse(int responseCode, string message)
        {
            ResponseCode = responseCode;
            Message = message;
        }
    }
    internal interface IHttpRequest
    { 
        void Post(string[] headers, string body, System.Action<UGSHttpResponse> callback);
    }

}
