using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static DataBase;
using static GameObjId;
using static AddedPrefab;
public class ForSummPower : MonoBehaviour
{
    public Text SummPower;
    private int NomberLine;
    private List<double> Power;
    private double SummingPower;

    DataBase DB = new DataBase();
    // Update is called once per frame
    void Start()
    {
        //Debug.Log(LinePower.Count);
        //for (int i = 0; i < LinePower.Count; i++)
        //{
        //    Debug.Log(LinePower[i].Text == SummPower);
            
        //    if (LinePower[i].Text == SummPower)
        //    {
        //        NomberLine = LinePower[i].count;
        //    }
        //}
       
    }
    public void UpdatingSummPower(int plase, double power)
    {
        int startColumn = (NomberLine - 1) * DataBase.GetCountColum() + 1;
        int endColumn = NomberLine * DataBase.GetCountColum();
        if (startColumn <= plase && plase <= endColumn)
        {
            SummingPower += power;
        }
        
        SummPower.text = string.Format("{0}", SummingPower);
    }
}
