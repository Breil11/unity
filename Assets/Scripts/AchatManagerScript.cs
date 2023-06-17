/*
using System.Net;
using System.IO;
using UnityEngine;



public static class AchatManagerScript
{
    public static AchatData GetNewAchatData()
    {
        HttpWebRequest request = (HttpWebRequest)WebResquest.Create("http://localhost:5082/api/Stand/GetStand");
        HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FronJson<AchatData>(json);

    }    
    f
}
*/