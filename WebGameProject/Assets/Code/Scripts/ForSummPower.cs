using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using static AddedPrefab;
using static GameObjId;
using static SpawnPlaseFD;
public class ForSummPower : MonoBehaviour
{
    public Text SummPower;
    public int NomberPlase1;
    public int NomberPlase2;
    private int nomberUbdate;
    private double Power;
    private int LineNomber;


    // Update is called once per frame
    void Update()
    {

        if (nomberUbdate == CountsUpdate.Count)
        {

        }
        else
        {
            nomberUbdate += 1;
        }

    }
    private void UpdatingSummPower()
    {
        SummPower.text = string.Format("{0}", Power);
    }
}
