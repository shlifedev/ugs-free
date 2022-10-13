using System;

namespace UGS.Runtime.Interfaces
{
    public class UGSHttpResponse
    {
        public string Message;
        public int ResponseCode;

        public UGSHttpResponse(int responseCode, string message)
        {
            ResponseCode = responseCode;
            Message = message;
        }
    }

    internal interface IHttpRequest
    {
        void Post(string[] headers, string body, Action<UGSHttpResponse> callback);
    }
}