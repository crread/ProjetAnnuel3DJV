using System;
using System.Collections;
using System.Text;
using Entity;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public bool isNetworkAvailable = false;
    private string _html = "http://apiprojetannuel/api";
    private UnityWebRequest _response;

    public bool requestTreated = false;
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
        StartCoroutine(PostRequestAsync($"{_html}/login", (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                // cannot reach the server
                ManageErrors(req);
            }
            else
            {
                GetComponent<DDOL>().player = JsonConvert.DeserializeObject<PlayerEntity>(req.downloadHandler.text);
            }

            requestTreated = true;
        }, json));
    }

    public void CreateAccount(string json)
    {
        StartCoroutine(PostRequestAsync($"{_html}/users", (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log(req.error);
                Debug.Log(req.error);
                ManageErrors(req);
            }
            else
            {
                // Debug.Log("YES BITCH");  
                // GetComponent<DDOL>().player = JsonConvert.DeserializeObject<PlayerEntity>(req.downloadHandler.text);
            }

            requestTreated = true;
        }, json));
    }

    public void UploadEndGameLevelData(string json)
    {
        StartCoroutine(PostRequestAsync($"{_html}/login", (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                // cannot reach the server
                ManageErrors(req);
            }
            else
            {
                // GetComponent<DDOL>().player = JsonConvert.DeserializeObject<PlayerEntity>(req.downloadHandler.text);
            }
        }, json));
    }

    private void ManageErrors(UnityWebRequest req)
    {
        if (!req.isHttpError && req.responseCode == 0)
        {
            GetComponent<DDOL>().responseRequest.httpCode = req.responseCode;
            GetComponent<DDOL>().responseRequest.detail = "cannot reach the server, try later";
        }
        else
        {
            GetComponent<DDOL>().responseRequest.httpCode = req.responseCode;
            GetComponent<DDOL>().responseRequest.detail = "email or password is wrong, try again";
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