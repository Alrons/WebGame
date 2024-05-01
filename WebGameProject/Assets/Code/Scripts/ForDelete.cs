using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static AddedPrefab;
using static DataBase;
using static GameObjId;
public class ForDelete : MonoBehaviour, IPointerClickHandler
{
    public GameObject GameObjects;
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; Added.Count > 0; i++)
        {
            if (Added[i].GameObject == GameObjects)
            {
                int rowNumber = (Added[i].Plase - 1) / CountColum + 1;
                for (int j = 0; j < LinePower.Count; j++)
                {
                    if (LinePower[j].count + 1 == rowNumber)
                    {
                        LinePower[j].Power -= Added[j].Power;
                        double SummingPower = LinePower[j].Power;
                        LinePower[j].Text.text = string.Format("{0}", SummingPower);
                    }
                }
                Destroy(Added[i].GameObject);
                Added.RemoveAt(i);
                break;

            }
        }
        
    }

}
