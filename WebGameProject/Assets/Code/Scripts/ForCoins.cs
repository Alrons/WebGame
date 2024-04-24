using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ForCoins : MonoBehaviour
{
    public static int CoinsOneBank = 1000;
    public static int CoinsTwoBank = 1000;
    public static int CoinsThreeBank = 1000;
    public static int CoinsFourBank = 1000;

    public Text CoinsOne;
    public Text CoinsTwo;
    public Text CoinsThree;
    public Text CoinsFour;

    

    void Start()
    {

        //����� �������� �� ����� ��� �� ������ ���� � �������� �� � ���������� �����

        CoinsOne.text = Convert.ToString(CoinsOneBank);
        CoinsTwo.text = Convert.ToString(CoinsTwoBank);
        CoinsThree.text = Convert.ToString(CoinsThreeBank);
        CoinsFour.text = Convert.ToString(CoinsFourBank);

    }

    
    void Update()
    {
        // ���� ���������� ���� ���������� �� �������� � ����� ��� �� �� ������, �� �� ���� �����������
        
        if (CoinsOne.text != Convert.ToString(CoinsOneBank))
        {
            //����� �������� �� ����� ��� �� ������ ���� � �������� �� � ���������� �����
            CoinsOne.text = Convert.ToString(CoinsOneBank);
        }
        else if (CoinsTwo.text != Convert.ToString(CoinsTwoBank))
        {
            CoinsTwo.text = Convert.ToString(CoinsTwoBank);
        }
        else if (CoinsThree.text != Convert.ToString(CoinsThreeBank))
        {
            CoinsThree.text = Convert.ToString(CoinsThreeBank);
        }
        else if (CoinsFour.text != Convert.ToString(CoinsFourBank))
        {
            CoinsFour.text = Convert.ToString(CoinsFourBank);
        }



    }

}
