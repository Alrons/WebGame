using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEditor.VersionControl;
using JetBrains.Annotations;
using static ClassOfItem;
using static SpawnObject;
using static AddedPrefab;
using static GameObjId;
using static ForCoins;
using static DataBase;
using Unity.VisualScripting;


public class DropDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    private RectTransform recetTransform;
    private Image image;// �������� � ������� 
    private Vector2 startPos;// ��������� �������
    private GameObject form;// ����� ���������� � ������� �� ����� ��������� ����� ��� �������� ��������

    public GameObject dragObject; // ��� ������
    
    public Text Title;//����� ��������� ������� 
    public Text price;//���� ���������� ������� 
    public Text Health;
    public Text Power;
    public Text XPower;
    public ScrollRect scrollRect;
    public Text IdRevard;
    // ���������� � �������� ����� ��������� ����������
    private int BackPrice; //���� �����
    private int BackHealth;
    private double BackPower;
    private double BackXPower;
    private int Place;

    public Transform Context;//�����
    private string FailBy;//������ ��� ����������� 


    private bool posNow;
    private int BackCurrency;

    void Start()
    {
        
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        // ���������� ������ (��� ���������� ��������) � ���������� ������ (������� � ������ � � �������), � ����������� �� ����� ������������ ����� ������� ����� �� ������ 
        for (int i = 0; i < GameObjects.Count; i++)
        {
            // ���������� ������
            if (GameObjects[i].GameObject == dragObject)
            {
                
                // ����� �� ������ ����� ����� � �������� � �����, ��� �� ����� ���������� �� ����� �����
                FindForm(list[i].Place);
                BackPrice = list[i].Price;
                BackHealth = list[i].Health;
                BackPower = list[i].Power;
                BackXPower = list[i].XPover;
                BackCurrency = list[i].�urrency;
                Place = list[i].Place;
            }
        }
        // ����� ��������� �������� �� ������ � ���������� 2 ������, ������� � ������ � ������� � ������� ���� ���������, �� �������� ����� 6
        
    }
    private void FindForm(int nomber)
    {
        for (int i = 0; i < PrefabFD.Count; i++)
        {
            if (PrefabFD[i].count == nomber)
            {
                form = PrefabFD[i].GameObject;
            }
        }
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == form)
        {
            posNow = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject == form)
        {
            posNow = false;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)//������� 
    {

        if (dragObject == GameObjects[^1].GameObject)
        {
            FindForm(list[^1].Place);
            BackPrice = list[^1].Price;
            BackHealth = list[^1].Health;
            BackPower = list[^1].Power;
            BackXPower = list[^1].XPover;
            BackCurrency = list[^1].�urrency;
            Place = list[^1].Place;
        }
        scrollRect.vertical = false;
        image.raycastTarget = false;
        startPos = image.transform.position; // ����� ���������� ����������� ������� � ����������
        form.GetComponent<Image>().color = new Color(255f,255f,255f,0.3f);//���������

    }

    

    public void OnDrag(PointerEventData eventData)// ����������� 
    {
        recetTransform.anchoredPosition += eventData.delta;
    }



    // ����� � ������ �� ���� 2 ������� � ��������� ����� ������� 
    private IEnumerator RetarnTitle()
    {
        yield return new WaitForSeconds(2);
        Title.text = FailBy;
        form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.1f);//���������
    }

    //����� ��������� � ����� BackPrice, coins*, posNow

    public void OnEndDrag(PointerEventData eventData)//��������� 
    {
        scrollRect.vertical = true;
        image.raycastTarget = true;



        if (posNow)
        {
            if(BackCurrency==1)
            {
                CoinsOneBank = Buy(BackPrice, CoinsOneBank);
            }
            else if(BackCurrency==2)
            {
                CoinsTwoBank = Buy(BackPrice, CoinsTwoBank);
            }
            else if (BackCurrency==3)
            {
                CoinsThreeBank = Buy(BackPrice, CoinsThreeBank);
            }
            else if (BackCurrency==4)
            {
                CoinsFourBank = Buy(BackPrice, CoinsFourBank);
            }
            //���� ���� �� �������� ������ ��� � ����
            
        }
        else
        {
            this.transform.position = startPos ;// ����������� �� ����� ���� ������� �� ����� 
            form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.1f);//���������

        }


    }
    
    private void MassagaIfAdded(string ChangeTitle)
    {
        form.GetComponent<Image>().color = new Color(255f, 0f, 0f, 0.5f);
        this.transform.position = startPos;// ����������� �� ����� ���� ������� �� �����
        FailBy = Title.text;//��������� ����� � ����������
        Title.text = ChangeTitle;// �������� ����� ������
        StartCoroutine(RetarnTitle());// ������� �� ����� � ������� ����� ������ �� 2 ������� � ��������� �������� 
    }

    public int Buy(int BackPrice, int coins)
    {
        if (BackPrice <= coins)
        {
            form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);//���������
            AddedPrefab addedPrefab = new AddedPrefab();
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//������������� � ��������

           
            if (addedPrefab.CheckIfAdded(Place))
            {

                MassagaIfAdded("����� ��� ������!");

            }
            else
            {
                int rowNumber = (Place - 1) / CountColum + 1;
                for (int i = 0; i < LinePower.Count; i++)
                {
                    Debug.Log($"1 {rowNumber}");
                    Debug.Log($"2 {LinePower[i].count}");    
                    if (LinePower[i].count + 1 == rowNumber)
                    {
                        LinePower[i].Power += BackPower;
                        double SummingPower = LinePower[i].Power;
                        LinePower[i].Text.text = string.Format("{0}", SummingPower);
                    }
                    
                   
                }
                CountsUpdate.Add(1);
                SpawnObject spawnObject = new SpawnObject();
                //��������� � ������ � ������� �������� ����������� ��������
                Added.Add(new AddedPrefab(Place, spawnObject.CopyPref(this.dragObject, this.transform.position, form.transform), BackHealth, BackPower, BackXPower));
                
                Destroy(this.dragObject); // ���������� ������ ������� �� ���������� 

            }


          
        }
        //���� ���� ������ ��� ���� � ����� �� �� 2 ������� ������ ����� �� ������ ���!
        else
        {
            MassagaIfAdded("������ ���!");

        }
         return coins = coins - BackPrice;// �������� �� �����
    }

}

