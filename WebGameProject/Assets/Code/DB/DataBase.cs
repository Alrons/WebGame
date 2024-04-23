using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static ClassOfItem;
using static SpawnPlaseFD;


public class DataBase : MonoBehaviour
{
    private string URL = "https://localhost:7017/AdminPanel/AllItems";
    private string URLSize = "https://localhost:7017/ManageSize/SizeTable";
    public int Currency;

    private void Start()
    {
        StartCoroutine(GetDatas());

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
                        stats[i]["health"], stats[i]["power"], stats[i]["xPover"], stats[i]["ñurrency"]));
                }
            }
        }
    }

}
