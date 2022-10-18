using System;
using System.Collections;
using System.Collections.Generic; 
using UGS.Runtime.Interfaces;
using UnityEngine;

namespace UGS.Runtime.Packages.ugs_free.Runtime.Core
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

        public void Post(string[] headers, string body, Action<UGSHttpResponse> callback)
        {
            if (runner == null)
            {
                var obj = new GameObject("UnityHttpRequest.CoroutineRunner");
                obj.hideFlags = HideFlags.HideAndDontSave;
                runner = obj.AddComponent<CoroutineRunner>();
                runner.onDestroy += this.OnDestroy;
            }

            runner.StartCoroutine(this.PostRoutine(headers, body, callback)); 
        }

        private void OnDestroy()
        {
            runner = null;
        }

        private IEnumerator PostRoutine(string[] headers, string body, Action<UGSHttpResponse> callback)
        {
            Debug.Log("PostRoutine");
            yield return null;
        }
    }
}
