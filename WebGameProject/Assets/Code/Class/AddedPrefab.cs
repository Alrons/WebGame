using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AddedPrefab: MonoBehaviour
{
    public int Plase { get; }
    public GameObject GameObject { get; }

    public int Health { get; set; }
    public double Power { get; set; }
    public double XPower { get; set; }

    //Создаем публичный список к которому будем обращяться из других фаилов
    public static List<int> CountUpdating = new List<int>();
    public static List<int> CountsUpdate = new List<int>();
    public static List<AddedPrefab> Added = new List<AddedPrefab>();


    public AddedPrefab()
    {

    }
    public AddedPrefab(int Plase, GameObject gameObject, int Health, double Power, double XPower)
    {
        this.Plase = Plase;
        this.GameObject = gameObject;
        this.Health = Health;
        this.Power = Power;
        this.XPower = XPower;

    }

    public bool CheckIfAdded(int plase)
    {
        bool answer = false;
        for (int i = 0; i < Added.Count; i++)
        {
            if (Added[i].Plase == plase) { answer = true; }   
        }
        return answer;
    }
    public void Updating(int Health, double Power, double XPower, int plase)
    {
        CountUpdating.Add(plase);
        for (int i = 0;i < Added.Count;i++)
        {
            if (plase == Added[i].Plase)
            {
                Added[i].Health = Health;
                Added[i].Power = Added[i].Power * XPower;
                Added[i].XPower = XPower;

            }
        }
    }

}

