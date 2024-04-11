using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using static AddedPrefab;
public class ForSummPower : MonoBehaviour
{
    public Text SummPower;
    private int Place1;
    private int NomberPlase1;
    private int NomberPlase2;
    private double PowerForPlace1;
    private double PowerForPlace2;
    private int Place2;
    private int countUpdate;
    private double powerNow;
    private int nomberUbdate;


    private void Start()
    {
        NomberPlase1 = 1;
        NomberPlase2 = 2;
    }
    // Update is called once per frame
    void Update()
    {

        if (nomberUbdate == CountsUpdate.Count)
        {
            
        }
        else
        {
            if (Added[^1].Plase == NomberPlase1)
            {
                if (countUpdate != CountUpdating.Count)
                {
                    UpdatingSummPower(2);
                    countUpdate = CountUpdating.Count;

                }
                else
                {
                    PowerForPlace1 += Added[^1].Power;
                    UpdatingSummPower(4);
                }
            }
            if (Added[^1].Plase == NomberPlase2)
            {
                if (countUpdate != CountUpdating.Count)
                {
                    UpdatingSummPower(3);
                    countUpdate = CountUpdating.Count;

                }
                else
                {
                    PowerForPlace2 += Added[^1].Power;
                    UpdatingSummPower(5);
                }
                
            }
            nomberUbdate += 1;
            

        }
        
    }
    private void UpdatingSummPower(int variant)
    {
        
        if (variant == 4)
        {
            powerNow += PowerForPlace1;
        }
        else if (variant == 5)
        {
            powerNow += PowerForPlace2;
        }
        else if (variant == 2)
        {
            powerNow += Added[countUpdate].Power - PowerForPlace1;

        }
        else
        {
            print(Added[countUpdate].Power);
            powerNow += Added[countUpdate].Power - PowerForPlace2;
 
        }
        SummPower.text = string.Format("{0}", powerNow);

    }
}
