using System;
using System.Collections;
using System.Text;
using Classes;
using Entity;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public bool isNetworkAvailable = false;
    private string _html = "http://apiprojetannuel/api";
    private UnityWebRequest _response;
    private void Start()
    {
        isNetworkAvailable = Application.internetReachability != NetworkReachability.NotReachable;
        //call every 5 secs CheckNetwork
        InvokeRepeating(nameof(CheckingNetwork), 5.0f, 5.0f); 
    }
    
    /// <summary>
    ///   <para>Check if the user has access to the internet.</para>
    /// </summary>
    public void CheckingNetwork()
    {
        isNetworkAvailable = Application.internetReachability != NetworkReachability.NotReachable;
    }

    /// <summary>
    ///   <para>Get user data from a request to an API or set error data.</para>
    /// </summary>
    /// <param name="json"></param>
    public void GetUser(string json)
    {
        PostRequestSync($"{_html}/login", (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                GetComponent<DDOL>().responseRequest = JsonConvert.DeserializeObject<ResponseRequestEntity>(req.downloadHandler.text);
                GetComponent<DDOL>().responseRequest.httpCode = req.responseCode;
            }
            else
            {
                GetComponent<DDOL>().player = JsonConvert.DeserializeObject<PlayerEntity>(req.downloadHandler.text);
            }
        }, json);
    }

    /// <summary>
    ///   <para>Make a synchronus POST request to given url.</para>
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callback"></param>
    /// <param name="json"></param>
    
    private void PostRequestSync(string url, Action<UnityWebRequest> callback, string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SendWebRequest();
            while (!request.isDone) {} // waiting for the response from the server
            callback(request);
        }
    }

    /// <summary>
    ///   <para>Make an asynchronus POST request to given url.</para>
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callback"></param>
    /// <param name="json"></param>
    
    private static IEnumerator PostRequestAsync(string url, Action<UnityWebRequest> callback, string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    /// <summary>
    ///   <para>Make an asynchronus GET request to given url.</para>
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callback"></param>
    /// <param name="param"></param>
    
    private static IEnumerator GetRequest(string url, Action<UnityWebRequest> callback, string param = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            callback(request);
        }
    }
}