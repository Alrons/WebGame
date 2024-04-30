using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static ClassOfItem;



public class DataBase : MonoBehaviour
{
    private string URL = "https://localhost:7139/api/Items";
    private string URLSize = "https://localhost:7139/api/SizeTables/1";
    public static int CountColum;
    public static int CountLine;


    public void Awake()
    {
        StartCoroutine(GetDatas());
        StartCoroutine(GetSize());
    }


    
    IEnumerator GetDatas() 
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
                Debug.Log(request.error);
            else
            {
                string json = request.downloadHandler.text;
                SimpleJSON.JSONNode stats = SimpleJSON.JSON.Parse(json);
                for (int i = 0; i < stats.Count; i++)
                {
                    //string title, string description, int price, string Image, int place, int Health, double Power, double XPover

                    list.Add(new ClassOfItem(stats[i]["title"], stats[i]["description"], stats[i]["price"], stats[i]["image"], stats[i]["place"],
                        stats[i]["health"], stats[i]["power"], stats[i]["xPover"], stats[i]["сurrency"]));
                }
            }
        }

    }// считывание Items 
    IEnumerator GetSize()
    {

        using (UnityWebRequest request = UnityWebRequest.Get(URLSize))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
                Debug.Log(request.error);
            else
            {
                string json = request.downloadHandler.text;
                SimpleJSON.JSONNode size = SimpleJSON.JSON.Parse(json);
                CountColum = size["height"];
                CountLine = size["width"];
            }
        }
    } //считываение размеров сетки
}

