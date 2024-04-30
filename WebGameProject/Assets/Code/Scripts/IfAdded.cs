using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static AddedPrefab;
using static DropDrag;


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
                
                Cheack = i+1;
                MyPlace = Added[i].Plase;
                DropDrag script = GameObject.GetComponent<DropDrag>();
                script.enabled = false;
            }
        }


    }
    private void Update()
    {
        
        if (Cheack != 0)
        {
            if (Added[Cheack-1].Health != int.Parse(Health.text))
            {
                Health.text = string.Format("{0}",Added[Cheack - 1].Health);
                Power.text = string.Format("{0}", Added[Cheack - 1].Power);

            }
        }
    }
}

