using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ForTotalPower : MonoBehaviour
{
    public Text SummPower;
    private double TotalPower;
    private int nomberUbdate;


    // Update is called once per frame
    void Update()
    {

        if (nomberUbdate == AddedPrefab.CountsUpdate.Count)
        {

        }
        else
        {
            TotalPower = 0;
            for (int i = 0; i < AddedPrefab.Added.Count; i++)
            {
                TotalPower += AddedPrefab.Added[i].Power;
            }
            UpdatingSummPower();
            nomberUbdate += 1;


        }

    }
    private void UpdatingSummPower()
    {
        SummPower.text = string.Format("{0}", TotalPower);
    }
}
