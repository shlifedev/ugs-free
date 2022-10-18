using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UGS.Runtime.Core;
using UGS.Runtime.Interfaces;
using UnityEngine;
using UnityEngine.Networking;

namespace UGS.Runtime 
{
    internal class UnityHttpRequest : IHttpRequest
    {
        private CoroutineRunner runner;

        class CoroutineRunner : MonoBehaviour
        {
            public event Action onDestroy;
            public void Run(IEnumerator coroutine)
            {
                StartCoroutine(coroutine); 
            }

            void OnApplicationQuit()
            {
                StopAllCoroutines();
            }
            void OnDestroy()
            { 
                StopAllCoroutines();
                onDestroy();
            }
        }

        public void Post(string url, (string k, string v)[] headers, string body, Action<UGSHttpResponse> callback)
        {
            if (runner == null)
            {
                var obj = new GameObject("UnityHttpRequest.CoroutineRunner");
                obj.hideFlags = HideFlags.HideAndDontSave;
                runner = obj.AddComponent<CoroutineRunner>();
                runner.onDestroy += this.OnDestroy;
            }

            runner.StartCoroutine(this.PostRoutine(url, headers, body, callback)); 
        }

        private void OnDestroy()
        {
            runner = null;
        }

        private IEnumerator PostRoutine(string url, (string k, string v)[] headers, string body, Action<UGSHttpResponse> callback)
        {

            UnityWebRequest request = UnityWebRequest.Post(url, body); 
            byte[] encodedBody = new System.Text.UTF8Encoding().GetBytes(body);
            request.uploadHandler = new UploadHandlerRaw(encodedBody);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            // headers
            headers.ToList().ForEach(x => { request.SetRequestHeader(x.k, x.v); });
            yield return request.SendWebRequest();
            if (request.responseCode == 200)
            {
                var response = JsonUtility.FromJson<UGSHttpResponse>(request.downloadHandler.text);
                callback?.Invoke(response);
            }
            else
            {
                if (!string.IsNullOrEmpty(request.downloadHandler.text))
                {
                    var response = JsonUtility.FromJson<UGSHttpResponse>(request.downloadHandler.text);
                    if(response != null) 
                        callback?.Invoke(response);
                }
                callback?.Invoke(new UGSHttpResponse((int)request.responseCode, request.error, null)); 
            }
            yield return null;
        }
    }
}
