using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEditor.VersionControl;
using static ForCoins;

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

    DataBase DB = new DataBase();
    
    void Start()
    {
        
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        // ���������� ������ (��� ���������� ��������) � ���������� ������ (������� � ������ � � �������), � ����������� �� ����� ������������ ����� ������� ����� �� ������ 
        for (int i = 0; i < GameObjId.GameObjects.Count; i++)
        {
            // ���������� ������
            if (GameObjId.GameObjects[i].GameObject == dragObject)
            {
                
                // ����� �� ������ ����� ����� � �������� � �����, ��� �� ����� ���������� �� ����� �����
                FindForm(ClassOfItem.list[i].Place);
                BackPrice = ClassOfItem.list[i].Price;
                BackHealth = ClassOfItem.list[i].Health;
                BackPower = ClassOfItem.list[i].Power;
                BackXPower = ClassOfItem.list[i].XPover;
                BackCurrency = ClassOfItem.list[i].�urrency;
                Place = ClassOfItem.list[i].Place;
            }
        }
        // ����� ��������� �������� �� ������ � ���������� 2 ������, ������� � ������ � ������� � ������� ���� ���������, �� �������� ����� 6
        
    }
    private void FindForm(int nomber)
    {
        for (int i = 0; i < GameObjId.PrefabFD.Count; i++)
        {
            if (GameObjId.PrefabFD[i].count == nomber)
            {
                form = GameObjId.PrefabFD[i].GameObject;
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

        if (dragObject == GameObjId.GameObjects[^1].GameObject)
        {
            FindForm(ClassOfItem.list[^1].Place);
            BackPrice = ClassOfItem.list[^1].Price;
            BackHealth = ClassOfItem.list[^1].Health;
            BackPower = ClassOfItem.list[^1].Power;
            BackXPower = ClassOfItem.list[^1].XPover;
            BackCurrency = ClassOfItem.list[^1].�urrency;
            Place = ClassOfItem.list[^1].Place;
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
                int rowNumber = (Place - 1) / (DataBase.GetCountColum()) + 1;
                for (int i = 0; i < GameObjId.LinePower.Count; i++)
                {
                    Debug.Log($"1 {rowNumber}");
                    Debug.Log($"2 {GameObjId.LinePower[i].count}");    
                    if (GameObjId.LinePower[i].count + 1 == rowNumber)
                    {
                        GameObjId.LinePower[i].Power += BackPower;
                        double SummingPower = GameObjId.LinePower[i].Power;
                        GameObjId.LinePower[i].Text.text = string.Format("{0}", SummingPower);
                    }
                    
                   
                }
                AddedPrefab.CountsUpdate.Add(1);
                SpawnObject spawnObject = new SpawnObject();
                //��������� � ������ � ������� �������� ����������� ��������
                AddedPrefab.Added.Add(new AddedPrefab(Place, spawnObject.CopyPref(this.dragObject, this.transform.position, form.transform), BackHealth, BackPower, BackXPower));
                
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

