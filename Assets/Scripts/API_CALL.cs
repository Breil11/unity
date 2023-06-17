/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;
using System.Net;

 

public class API_CALL : MonoBehaviour
{


    public class Stand
    {
        public int idStand { get; set; }
        public string name { get; set; }
        public int prix { get; set; }
    }

    public TextMeshProUGUI text;

    void Start()
    {

    }
    /*
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return WebRequest.SendWebRequest();

        }
        switch (WebRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(String.Format("Something went wrong: {0}", WebRequest.error));
                break;
            case UnityWebRequest.Result.Success:
                Stand stand = JsonConvert.DeserializeObject<Stand>(webRequest.downloadHand1erl.text);
                text.text = stand.name;
                break;
        }
    }
    */
/*
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError($"Something went wrong: {request.error}");
            }
            else if (request.result == UnityWebRequest.Result.Success)
            {
                Stand stand = JsonConvert.DeserializeObject<Stand>(request.downloadHandler.text);
                text.text = stand.name;
            }
        }
    }




}
*/