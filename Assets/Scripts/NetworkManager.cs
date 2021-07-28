using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public bool isNetworkAvailable = false;
    private string _html = "http://lasauce/";
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
    /// <param name="form"></param>
    public void GetUser(WWWForm form)
    {
        StartCoroutine(PostRequestAsync($"{_html}?entity=user&type=get", (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                ManageErrors(req);
            }
            else
            {
                GetComponent<DDOL>().player = JsonConvert.DeserializeObject<PlayerEntity>(req.downloadHandler.text);
            }

            requestTreated = true;
        }, form));
    }

    public void GetScores(WWWForm form, List<ScoreEntity> scores, List<ScoreEntity> score)
    {
        StartCoroutine(PostRequestAsync($"{_html}?entity=score&type=gets", (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                ManageErrors(req);
            }
            else
            {
                JObject json = JObject.Parse(req.downloadHandler.text);

                foreach (var item in json["score"])
                {
                    scores.Add(JsonConvert.DeserializeObject<ScoreEntity>(item.ToString()));
                }
                
                if (json["personnalScore"] != null)
                {
                    score.Add(JsonConvert.DeserializeObject<ScoreEntity>(json["personnalScore"].ToString()));
                }
            }

            requestTreated = true;
        }, form));
    }

    public void CreateAccount(WWWForm form)
    {
        StartCoroutine(PostRequestAsync($"{_html}?entity=user&type=create", (UnityWebRequest req) =>
        {
            Debug.Log(req.downloadHandler.text);
            if (req.isNetworkError || req.isHttpError)
            {
                ManageErrors(req);
            }
            else
            {
                GetComponent<DDOL>().player = JsonConvert.DeserializeObject<PlayerEntity>(req.downloadHandler.text);
            }

            requestTreated = true;
        }, form));
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
    /// <param name="form"></param>
    
    private static IEnumerator PostRequestAsync(string url, Action<UnityWebRequest> callback, WWWForm form)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
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