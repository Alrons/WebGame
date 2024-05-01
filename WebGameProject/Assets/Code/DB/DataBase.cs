using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static ClassOfItem;



public class DataBase
{
    private string URL = "https://localhost:7139/api/Items";
    private string URLSize = "https://localhost:7139/api/SizeTables/1";
    private static int _countColum;
    private static int _countLine;

    public static int  GetCountColum() {  return _countColum; }
    public static int GetCountLine() { return _countLine;}
    
    
    public IEnumerator GetItems() 
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

                    ClassOfItem.list.Add(new ClassOfItem(stats[i]["title"], stats[i]["description"], stats[i]["price"], stats[i]["image"], stats[i]["place"],
                        stats[i]["health"], stats[i]["power"], stats[i]["xPover"], stats[i]["сurrency"]));
                }
            }
        }

    }// считывание Items 
    public  IEnumerator GetSize()
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
                _countColum = size["height"];
                _countLine = size["width"];
            }
        }
    } //считываение размеров сетки
}

