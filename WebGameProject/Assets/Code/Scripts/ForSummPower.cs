using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using static AddedPrefab;
public class ForSummPower : MonoBehaviour
{
    public Text SummPower;
    public int NomberPlase1;
    public int NomberPlase2;
    private double PowerForPlace1;
    private double PowerForPlace2;
    private int nomberUbdate;


    // Update is called once per frame
    void Update()
    {

        if (nomberUbdate == CountsUpdate.Count)
        {
            
        }
        else
        {
            for (int i = 0; i < Added.Count; i++)
            {
                if (NomberPlase1 == Added[i].Plase)
                {
                    
                    if (Added[i].Power != PowerForPlace1) 
                    {

                        PowerForPlace1 = Added[i].Power;
                        UpdatingSummPower();
                    }
                }
                if (NomberPlase2 == Added[i].Plase)
                {
                    if (Added[i].Power != PowerForPlace2)
                    {
                        PowerForPlace2 = Added[i].Power;
                        UpdatingSummPower();
                    }
                }
            }
            nomberUbdate += 1;
            

        }
        
    }
    private void UpdatingSummPower()
    {
        SummPower.text = string.Format("{0}", PowerForPlace1 + PowerForPlace2);
    }
}
