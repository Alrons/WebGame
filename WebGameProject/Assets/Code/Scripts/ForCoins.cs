using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ClassOfItem;

public class ForCoins : MonoBehaviour
{
    public static int CoinsOnebank = 1000;
    public static int CoinsTwoBank = 1000;
    public static int CoinsThreeBank = 1000;
    public static int CoinsFourBank = 1000;

    public Text CoinsOne;
    public Text CoinsTwo;
    public Text CoinsThree;
    public Text CoinsFour;

    

    void Start()
    {

        //берем значение из места где мы храним цену и заменяем ее в визуальной части

        CoinsOne.text = Convert.ToString(CoinsOnebank);
        CoinsTwo.text = Convert.ToString(CoinsTwoBank);
        CoinsThree.text = Convert.ToString(CoinsThreeBank);
        CoinsFour.text = Convert.ToString(CoinsFourBank);

    }

    
    void Update()
    {
        // Если визуальная цена отличается от значения в месте где мы ее храним, то мы наще колличество
        
        if (CoinsOne.text != Convert.ToString(CoinsOnebank))
        {
            //берем значение из места где мы храним цену и заменяем ее в визуальной части
            CoinsOne.text = Convert.ToString(CoinsOnebank);
        }
        //else if(CoinsTwo.text != Convert.ToString(CoinsTwoBank))
        //{
        //    CoinsOne.text = Convert.ToString(CoinsTwoBank);
        //}
        //else if (CoinsThree.text != Convert.ToString(CoinsThreeBank))
        //{
        //    CoinsOne.text = Convert.ToString(CoinsThreeBank);
        //}
        //else if (CoinsFour.text != Convert.ToString(CoinsFourBank))
        //{
        //    CoinsOne.text = Convert.ToString(CoinsFourBank);
        //}



    }
    
}
