using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEditor.VersionControl;
using JetBrains.Annotations;
using static spawnobject;
using Unity.VisualScripting;

public class DropDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    private RectTransform recetTransform; 
    private Image image;// �������� � ������� 
    private Vector2 startPos;// ��������� �������
    private GameObject form;// ����� ���������� � ������� �� ����� ��������� ����� ��� �������� ��������
    public GameObject Form1;//����� ���� �� ����� ��������� �����
    public GameObject Form2;//����� ���� �� ����� ��������� �����
    public GameObject Form3;//����� ���� �� ����� ��������� �����
    public GameObject Form4;//����� ���� �� ����� ��������� �����
    public GameObject Form5;//����� ���� �� ����� ��������� �����
    public GameObject Form6;//����� ���� �� ����� ��������� ����� 
    public Text Title;//����� ��������� ������� 
    public Text price;//���� ���������� ������� 
    public Transform Context;//�����
    private string FailBy;//������ ��� ����������� 

    private void Awake()
    {
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        // ���������� ������ (��� ���������� ��������) � ���������� ������ (������� � ������ � � �������), � ����������� �� ����� ������������ ����� ������� ����� �� ������ 
        for (int i = 0; i < list.Count; i++)
        {
            // ���������� ������
            if (list[i].Title == Title.text)
            {
                // ����� �� ������ ����� ����� � �������� � �����, ��� �� ����� ���������� �� ����� �����
                metod(list[i].Place);
            }
        }
        

    }

    public void OnBeginDrag(PointerEventData eventData)//������� 
    {
        image.raycastTarget = false;

        // ����� ��������� �������� �� ������ � ���������� 2 ������, ������� � ������ � ������� � ������� ���� ���������, �� �������� ����� 6
        if (Title.text == list[^1].Title)
        {
            metod(6);
        }
        startPos = image.transform.position; // ����� ���������� ����������� ������� � ����������
        

    }

    // ����� � ������� �� ������ �� ����� �������� ����� ����� ����������, ����������� ��� ����������� �������������� 
    private void metod(int nomber)
    {
        print(nomber);
        if (nomber == 1)  // ���� ����� 1 �� ����� ������ �� ����� 1
            form = Form1;
        else if (nomber == 2) form = Form2; // ���� ����� 2 �� ����� ������ �� ����� 2 
        else if (nomber == 3) form = Form3; // ���� ����� 3 �� ����� ������ �� ����� 3 
        else if (nomber == 4) form = Form4; // ���� ����� 4 �� ����� ������ �� ����� 4 
        else if (nomber == 5) form = Form5; // ���� ����� 5 �� ����� ������ �� ����� 5 
        else if (nomber == 6) form = Form6; // ���� ����� 6 �� ����� ������ �� ����� 6 
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
    }
    public void OnEndDrag(PointerEventData eventData)//��������� 
    {
        image.raycastTarget = true;
        Vector2 posObject = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;//���������� ������� �������
        print (form.GetComponent<RectTransform>().anchoredPosition); // ������ ����

        //����� ������� ����� � ������� ����� ���������
        Vector2 posForm = form.GetComponent<RectTransform>().anchoredPosition;

        // ���������� 
        if (MathF.Abs(posObject.x - posForm.x) <= 100f &&
            MathF.Abs(posObject.y - posForm.y) <= 100f)//��� ������ ����������
        {
            // �������� ���� �� �����
            if (int.Parse(price.text) <= coins)
            {
                this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//������������� � ��������
                coins = coins - int.Parse(price.text);// �������� �� �����

            }

            //���� ���� ������ ��� ���� � ����� �� �� 2 ������� ������ ����� �� ������ ���!
            else
            {
                image.transform.position = startPos;// ����������� �� ����� ���� ������� �� �����
                FailBy = Title.text;//��������� ���� � ����������
                Title.text = "������ ���!";// ��������� ����� ������
                StartCoroutine(RetarnTitle());// ������� �� ����� � ������� ����� ������ �� 2 ������� � ��������� �������� 

            }
                                                                                                      


        }
        else
        {
            image.transform.position = startPos;// ����������� �� ����� ���� ������� �� ����� 

        }

    }

}
