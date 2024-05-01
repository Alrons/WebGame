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
                        GameObjId.LinePower[j].Power -= AddedPrefab.Added[i].Power;
                        double SummingPower = GameObjId.LinePower[j].Power;
                        GameObjId.LinePower[j].Text.text = string.Format("{0}", SummingPower);
                    }
                }
                int Back = ((int)(AddedPrefab.Added[i].Price * 0.5));
                if (AddedPrefab.Added[i].Ñurrency == 1) { ForCoins.CoinsOneBank += (Back); }
                if (AddedPrefab.Added[i].Ñurrency == 2) { ForCoins.CoinsTwoBank += (Back); }
                if (AddedPrefab.Added[i].Ñurrency == 3) { ForCoins.CoinsThreeBank += (Back); }
                if (AddedPrefab.Added[i].Ñurrency == 4) { ForCoins.CoinsFourBank += (Back); }
                Destroy(AddedPrefab.Added[i].GameObject);
                AddedPrefab.Added.RemoveAt(i);
                break;

            }
        }
        
    }

}
