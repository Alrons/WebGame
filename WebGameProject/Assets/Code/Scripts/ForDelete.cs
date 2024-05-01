using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class ForDelete : MonoBehaviour, IPointerClickHandler
{
    DataBase DB = new DataBase();
    public GameObject GameObjects;
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; AddedPrefab.Added.Count > 0; i++)
        {
            if (AddedPrefab.Added[i].GameObject == GameObjects)
            {
                int rowNumber = (AddedPrefab.Added[i].Plase - 1) / DataBase.GetCountColum() + 1;
                for (int j = 0; j < GameObjId.LinePower.Count; j++)
                {
                    if (GameObjId.LinePower[j].count + 1 == rowNumber)
                    {
                        GameObjId.LinePower[j].Power -= AddedPrefab.Added[j].Power;
                        double SummingPower = GameObjId.LinePower[j].Power;
                        GameObjId.LinePower[j].Text.text = string.Format("{0}", SummingPower);
                    }
                }
                Destroy(AddedPrefab.Added[i].GameObject);
                AddedPrefab.Added.RemoveAt(i);
                break;

            }
        }
        
    }

}
