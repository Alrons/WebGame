using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bonus : MonoBehaviour
{
    public Text banck;
    public void Start()
    {
              
        banck.text = PlayerPrefs.GetInt("coins").ToString();
        
        

        
    }

}
