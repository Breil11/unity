using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetDataStand : MonoBehaviour
{
    public Renderer targetRenderer; // Le composant Renderer de l'objet où vous souhaitez appliquer la texture de l'image

    IEnumerator Start()
    {
        string apiUrl = "http://localhost:5082/api/Achat/GetAchat"; // L'URL de votre API pour récupérer les données de l'image

        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Récupérer les données de l'image depuis la réponse de l'API
            byte[] imageData = request.downloadHandler.data;

            // Créer une texture à partir des données de l'image
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(imageData);

            // Appliquer la texture à l'objet cible
            targetRenderer.material.mainTexture = texture;
        }
        else
        {
            Debug.LogError("Erreur lors de la récupération des données de l'image : " + request.error);
        }
    }
}
