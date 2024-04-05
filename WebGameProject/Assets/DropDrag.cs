using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEditor.VersionControl;
using JetBrains.Annotations;

public class DropDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    private RectTransform recetTransform;
    private Image image;
    private Vector2 startPos;// ��������� �������
    public GameObject form;//����� ���������� ����� �� ������ 
    

    private void Awake()
    {
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)//������� 
    {

        image.raycastTarget = false;
        
        startPos = image.transform.position;

    }

    public void OnDrag(PointerEventData eventData)// �����������
    {
        recetTransform.anchoredPosition += eventData.delta;
        print(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);

    }

    public void OnEndDrag(PointerEventData eventData)//��������� 
    {

        image.raycastTarget = true;
        Vector2 posObject = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;//���������� ������� �������
        Vector2 pos  = image.transform.position;
        Vector2 posForm =form.GetComponent<RectTransform>().anchoredPosition;

        if (MathF.Abs(posObject.x - posForm.x) <= 100f &&
            MathF.Abs(posObject.y - posForm.y) <= 100f)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//�������������     


        }
        else
        {
            image.transform.position = startPos;// ����������� �� ����� ���� ������� �� ����� 

        }

    }

}
