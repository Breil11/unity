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


        // Créez un objet anonyme avec les données à envoyer
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

        // Convertissez l'objet en chaîne JSON
        string jsonPayload = JsonUtility.ToJson(data);

        // Créez un objet UnityWebRequest
        UnityWebRequest request = new UnityWebRequest(uri, "POST");

        // Ajoutez l'en-tête de type de contenu
        request.SetRequestHeader("Content-Type", "application/json");

        // Convertissez la chaîne JSON en tableau d'octets et affectez-le à la donnée de requête
        byte[] payload = Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(payload);
        request.downloadHandler = new DownloadHandlerBuffer();

        // Envoyez la requête et attendez la réponse
        yield return request.SendWebRequest();

        // Vérifiez s'il y a eu des erreurs
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            outputArea.text = request.error;
        else
            outputArea.text = request.downloadHandler.text;

        // N'oubliez pas de libérer la mémoire en supprimant l'objet UnityWebRequest
        request.Dispose();
    }
}
