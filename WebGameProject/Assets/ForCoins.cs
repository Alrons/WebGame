using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static spawnobject;

public class ForCoins : MonoBehaviour
{
    public Text Coins;
    // Start is called before the first frame update
    void Start()
    {
        Coins.text = Convert.ToString(coins);
    }

    // Update is called once per frame
    void Update()
    {
        if (Coins.text != Convert.ToString(coins)) 
        {
            Coins.text = Convert.ToString(coins);
        }
    }
}
