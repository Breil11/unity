using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System.Text;

public class PostMethod : MonoBehaviour
{
    public TextMeshProUGUI outputArea;
    public Button postButton;

    void Start()
    {
        postButton.onClick.AddListener(PostData);
    }

    void PostData()
    {
        StartCoroutine(PostData_Coroutine());
    }

    IEnumerator PostData_Coroutine()
    {
        //outputArea.text = "Loading...";

        //string uri = "http://localhost:5082/api/Achat";
        string uri = "http://localhost:5082/api/Visiteur";


        // Cr�ez un objet anonyme avec les donn�es � envoyer
        var data = new
        {
            IdAchat = 9,
            standId = 2,
            Firstname = "breil",
            Date = "2023-06-14"
        };
        /*
        var data = new
        {
            "idVisiteur": 0,
            FirstName = "breil",
            LastName = "breil",
            PhoneNumber = "test",
            Email = "test",
            ZipCode = "test",
            City = "test",
            Interest = "test"
        };*/

        // Convertissez l'objet en cha�ne JSON
        string jsonPayload = JsonUtility.ToJson(data);

        // Cr�ez un objet UnityWebRequest
        UnityWebRequest request = new UnityWebRequest(uri, "POST");

        // Ajoutez l'en-t�te de type de contenu
        request.SetRequestHeader("Content-Type", "application/json");

        // Convertissez la cha�ne JSON en tableau d'octets et affectez-le � la donn�e de requ�te
        byte[] payload = Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(payload);
        request.downloadHandler = new DownloadHandlerBuffer();

        // Envoyez la requ�te et attendez la r�ponse
        yield return request.SendWebRequest();

        // V�rifiez s'il y a eu des erreurs
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            outputArea.text = request.error;
        else
            outputArea.text = request.downloadHandler.text;

        // N'oubliez pas de lib�rer la m�moire en supprimant l'objet UnityWebRequest
        request.Dispose();
    }
}
