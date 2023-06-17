using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class GetMethod : MonoBehaviour
{
    public TextMeshProUGUI outputArea;
    public Button getButton;

    void Start()
    {
        getButton.onClick.AddListener(GetData);
    }

    void GetData()
    {
        StartCoroutine(GetData_Coroutine());
    }

    IEnumerator GetData_Coroutine()
    {
    //outputArea.text = "Loading...";
        string uri = "http://localhost:5082/api/Achat";
        //string uri = "http://localhost:5082/api/Visiteur/GetVisiteurs";

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                outputArea.text = request.error;
            else
                outputArea.text = request.downloadHandler.text;
        }
    }
}
