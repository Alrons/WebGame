using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static AddedPrefab;
public class ForDelete : MonoBehaviour, IPointerClickHandler
{
    public GameObject GameObjects;
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; Added.Count > 0; i++)
        {
            if (Added[i].GameObject == GameObjects)
            {
                Destroy(Added[i].GameObject);
                Added.RemoveAt(i);
                break;

            }
        }
        
    }

}
