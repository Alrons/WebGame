using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static AddedPrefab;

public class IfAdded : MonoBehaviour
{
    public GameObject GameObject;
    public Text Health;
    public Text Power;
    public Text XPower;
    private int Cheack;
    public static int MyPlace;


    private void Start()
    {
        Cheack = 0;
        for (int i = 0; i < Added.Count; i++)
        {
            if (Added[i].GameObject == GameObject)
            {
                print(Cheack);
                Cheack = i+1;
                MyPlace = Added[i].Plase;
            }
        }

    }
    private void Update()
    {
        
        if (Cheack != 0)
        {
            if (Added[Cheack-1].Health != int.Parse(Health.text))
            {
                
                Health.text = string.Format("{0}",Added[Cheack - 1].Health * Added[Cheack - 1].XPower);
                Power.text = string.Format("{0}", Added[Cheack - 1].Power * Added[Cheack - 1].XPower);

            }
        }
    }
}

