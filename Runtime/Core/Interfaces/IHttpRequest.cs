using System;

namespace UGS.Runtime.Interfaces
{
    public class UGSHttpResponse
    {
        public int Code;
        public string Message;
        public string Data;

        public UGSHttpResponse(int code, string message, string data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
    }

    internal interface IHttpRequest
    {
        void Post(string[] headers, string body, Action<UGSHttpResponse> callback);
    }
}