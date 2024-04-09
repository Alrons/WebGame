using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ClassOfItem;

public class ForCoins : MonoBehaviour
{
    public Text Coins;
    // Start is called before the first frame update
    void Start()
    {
        //берем значение из места где мы храним цену и заменяем ее в визуальной части
        Coins.text = Convert.ToString(coins);
    }

    // Update is called once per frame
    void Update()
    {
        // Если визуальная цена отличается от значения в месте где мы ее храним, то мы наще колличество
        if (Coins.text != Convert.ToString(coins)) 
        {
            //берем значение из места где мы храним цену и заменяем ее в визуальной части
            Coins.text = Convert.ToString(coins);
        }
    }
}
