using System;
using System.Collections.Generic;

namespace UGS.Runtime.Interfaces
{
   
    public class UGSBaseRequest
    {
        public class PostData<T>  
        {
            public string action;
            public T payload; 

            public PostData(string action, T payload)
            {
                this.payload = payload;
                this.action = action;
            }
        }

        public class Action
        {
            public string action;
        }
        public class Option
        {

        }

        public class Payload
        {
            public Dictionary<string, object> payload;

            public Payload(Dictionary<string, object> payload)
            {
                this.payload = payload;
            }
        }
    }
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

    public interface IHttpRequest
    {
        void Post(string url, (string k, string v)[] headers, string body, Action<UGSHttpResponse> callback);
    }
}