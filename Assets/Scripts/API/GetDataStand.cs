using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetDataStand : MonoBehaviour
{
    public Renderer targetRenderer; // Le composant Renderer de l'objet o� vous souhaitez appliquer la texture de l'image

    IEnumerator Start()
    {
        string apiUrl = "http://localhost:5082/api/Achat/GetAchat"; // L'URL de votre API pour r�cup�rer les donn�es de l'image

        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // R�cup�rer les donn�es de l'image depuis la r�ponse de l'API
            byte[] imageData = request.downloadHandler.data;

            // Cr�er une texture � partir des donn�es de l'image
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(imageData);

            // Appliquer la texture � l'objet cible
            targetRenderer.material.mainTexture = texture;
        }
        else
        {
            Debug.LogError("Erreur lors de la r�cup�ration des donn�es de l'image : " + request.error);
        }
    }
}
