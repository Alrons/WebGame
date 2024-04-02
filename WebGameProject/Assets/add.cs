using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class add : MonoBehaviour
{
    public Transform panel;
    public GameObject prefab;
    public List<ListElement> element;
    public ListElement elementList;

    private void Awake()
    {
       
    }
    public void CreatBlock()
    {
        GameObject tempElement = Instantiate(prefab, panel);
        element.Add(tempElement.GetComponent<ListElement>());
        

    }
     
    


}
    
