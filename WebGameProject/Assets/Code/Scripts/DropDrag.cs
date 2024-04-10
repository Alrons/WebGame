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
using static IfAdded;
using Unity.VisualScripting;


public class DropDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    private RectTransform recetTransform;
    private Image image;// �������� � ������� 
    private Vector2 startPos;// ��������� �������
    private GameObject form; // ����� ���������� � ������� �� ����� ��������� ����� ��� �������� ��������

    public GameObject dragObject; // ��� ������
 
    public GameObject Form1;//����� ���� �� ����� ��������� �����
    public GameObject Form2;//����� ���� �� ����� ��������� �����
    public GameObject Form3;//����� ���� �� ����� ��������� �����
    public GameObject Form4;//����� ���� �� ����� ��������� �����
    public GameObject Form5;//����� ���� �� ����� ��������� �����
    public GameObject Form6;//����� ���� �� ����� ��������� ����� 

    public Text Title;//����� ��������� ������� 
    public Text price;//���� ���������� ������� 
    public Text Health;
    public Text Power;
    public Text XPower;
    public ScrollRect scrollRect;

    // ���������� � �������� ����� ��������� ����������
    private int BackPrice;
    private int BackHealth;
    private double BackPower;
    private double BackXPower;
    private int Place;

    public Transform Context;//�����
    private string FailBy;//������ ��� ����������� 







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
            }
        }
        // ����� ��������� �������� �� ������ � ���������� 2 ������, ������� � ������ � ������� � ������� ���� ���������, �� �������� ����� 6
        
    }
    private void FindForm(int nomber)
    {
        Place = nomber;
        if (nomber == 1) form = Form1; // ���� ����� 1 �� ����� ������ �� ����� 1
        else if (nomber == 2) form = Form2; // ���� ����� 2 �� ����� ������ �� ����� 2 
        else if (nomber == 3) form = Form3; // ���� ����� 3 �� ����� ������ �� ����� 3 
        else if (nomber == 4) form = Form4; // ���� ����� 4 �� ����� ������ �� ����� 4 
        else if (nomber == 5) form = Form5; // ���� ����� 5 �� ����� ������ �� ����� 5 
        else if (nomber == 6) form = Form6; // ���� ����� 6 �� ����� ������ �� ����� 6 
    }
    public void OnBeginDrag(PointerEventData eventData)//������� 
    {
        if (dragObject == GameObjects[^1].GameObject)
        {
            FindForm(6);
            BackPrice = list[^1].Price;
            BackHealth = list[^1].Health;
            BackPower = list[^1].Power;
            BackXPower = list[^1].XPover;
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



    public void OnEndDrag(PointerEventData eventData)//��������� 
    {
        scrollRect.vertical = true;
        image.raycastTarget = true;
        Vector2 posObject = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;//���������� ������� �������

        //����� ������� ����� � ������� ����� ���������
        Vector2 posForm = form.GetComponent<RectTransform>().anchoredPosition;
        

        // ���������� 
        if (MathF.Abs(posObject.x - posForm.x) <= 100f &&
            MathF.Abs(posObject.y - posForm.y) <= 100f &&
            MathF.Abs(Context.transform.position.y - Context.transform.position.y) <= 100f)//��� ������ ����� �� ����������
        {
            
            // ���� ���� �� �������� ������ ��� � ���� 
            if (BackPrice <= coins)
            {
                AddedPrefab addedPrefab = new AddedPrefab();
                this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//������������� � ��������
                
                form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);//���������
                if (addedPrefab.CheckIfAdded(Place))
                {
                    addedPrefab.Updating(BackHealth,BackPower,BackXPower,Place);
                    Destroy(dragObject);

                }
                else
                {//��������� � ������ � ������� �������� ����������� ��������
                    Added.Add(new AddedPrefab(Place, CopyPref(this.dragObject, this.transform.position, form.transform), BackHealth, BackPower, BackXPower));
                    Destroy(this.dragObject); // ���������� ������ ������� �� ���������� 
                }
                
                
                print(BackPrice);
                coins = coins - BackPrice;// �������� �� �����
            }
            //���� ���� ������ ��� ���� � ����� �� �� 2 ������� ������ ����� �� ������ ���!
            else
            {
                form.GetComponent<Image>().color = new Color(255f, 0f, 0f, 0.5f);
                this.transform.position = startPos;// ����������� �� ����� ���� ������� �� �����
                FailBy = Title.text;//��������� ����� � ����������
                Title.text = "������ ���!";// �������� ����� ������
                StartCoroutine(RetarnTitle());// ������� �� ����� � ������� ����� ������ �� 2 ������� � ��������� �������� 
                
            }
        }
        else
        {
            this.transform.position = startPos ;// ����������� �� ����� ���� ������� �� ����� 
            form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.1f);//���������

        }

    }

}
