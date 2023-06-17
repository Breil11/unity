/* avec la conversion
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System.Text;

public class RegistrationForm : MonoBehaviour
{
    public TextMeshProUGUI outputArea;
    public Button postButton;
    public InputField firstNameInput;
    public InputField lastNameInput;
    public InputField phoneNumberInput;
    public InputField emailInput;
    public InputField postalCodeInput;
    public InputField subjectInput;
    public InputField cityInput;

    void Start()
    {
        postButton.onClick.AddListener(PostData);
    }

    void PostData()
    {
        // Récupérer les valeurs des Input Fields
        string firstName = firstNameInput.text;
        string lastName = lastNameInput.text;
        string phoneNumber = phoneNumberInput.text;
        string email = emailInput.text;
        string postalCode = postalCodeInput.text;
        string subject = subjectInput.text;
        string city = cityInput.text;

        // Afficher les valeurs récupérées dans la console
        Debug.Log("First Name: " + firstName);
        Debug.Log("Last Name: " + lastName);
        Debug.Log("Phone Number: " + phoneNumber);
        Debug.Log("Email: " + email);
        Debug.Log("Postal Code: " + postalCode);
        Debug.Log("Subject: " + subject);
        Debug.Log("City: " + city);

        StartCoroutine(PostData_Coroutine(firstName, lastName, phoneNumber, email, postalCode, subject, city));
    }

    IEnumerator PostData_Coroutine(string firstName, string lastName, string phoneNumber, string email, string postalCode, string subject, string city)
    {
        string uri = "http://localhost:5082/api/Visiteur";

        var data = new
        {
            idVisiteur = 23,
            firstName = firstName,
            lastName = lastName,
            phoneNumber = int.Parse(phoneNumber),
            email = email,
            zipCode = postalCode,
            city = city,
            interest = subject
        };

        string jsonPayload = JsonUtility.ToJson(data);
        Debug.Log("JSON Payload: " + jsonPayload); // Ajoutez cette ligne pour afficher le JSON dans la console

        UnityWebRequest request = new UnityWebRequest(uri, "POST");

        request.SetRequestHeader("Content-Type", "application/json");

        byte[] payload = Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(payload);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            outputArea.text = request.error;
        else
            outputArea.text = request.downloadHandler.text;

        Debug.Log("Response: " + request.downloadHandler.text);

        request.Dispose();
    }
}
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class RegistrationForm : MonoBehaviour
{
    public InputField firstNameInput;
    public InputField lastNameInput;
    public InputField phoneNumberInput;
    public InputField emailInput;
    public InputField zipCodeInput;
    public InputField interestInput;
    public InputField cityInput;

    public Button submitButton;

    public void Start()
    {
        // Ajouter un écouteur d'événement au bouton pour appeler OnSubmitButtonClick()
        submitButton.onClick.AddListener(OnSubmitButtonClick);
    }

    public void OnSubmitButtonClick()
    {
        // Récupérer les valeurs des champs de saisie
        /*string firstName = firstNameInput.text;
        string lastName = lastNameInput.text;
        int phoneNumber = int.Parse(phoneNumberInput.text); // Convertir en int
        string email = emailInput.text;
        string zipCode = zipCodeInput.text;
        string interest = interestInput.text;
        string city = cityInput.text;*/

        string firstName = "breilito";
        string lastName = "breilito";
        int phoneNumber = 12; // Convertir en int
        string email = "breilito";
        string zipCode = "breilito";
        string interest = "breilito";
        string city = "breilito";




        // Créer un objet pour contenir les données de l'utilisateur
        User user = new User(firstName, lastName, phoneNumber, email, zipCode, interest, city);

        // Convertir l'objet User en JSON
        string jsonPayload = JsonUtility.ToJson(user);

        // Afficher le JSON dans la console pour vérification
        Debug.Log("JSON Payload: " + jsonPayload);

        // Envoyer les données à l'API
        StartCoroutine(PostData(jsonPayload));
    }

    private IEnumerator PostData(string jsonPayload)
    {
        // URL de l'API
        string url = "http://localhost:5082/api/Visiteur";

        // Créer un objet UnityWebRequest pour envoyer la requête POST
        UnityWebRequest request = UnityWebRequest.Post(url, jsonPayload);

        // Définir les en-têtes de la requête
        request.SetRequestHeader("Content-Type", "application/json");

        // Envoyer la requête
        yield return request.SendWebRequest();

        // Vérifier s'il y a eu une erreur lors de la requête
        if (request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Request Error: " + request.error);
        }
        else
        {
            // Afficher la réponse de la requête dans la console
            Debug.Log("Response: " + request.downloadHandler.text);
        }
    }
}

[System.Serializable]
public class User
{
    public string firstName;
    public string lastName;
    public int phoneNumber;
    public string email;
    public string zipCode;
    public string interest;
    public string city;

    public User(string firstName, string lastName, int phoneNumber, string email, string zipCode, string interest, string city)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.zipCode = zipCode;
        this.interest = interest;
        this.city = city;
    }
}

