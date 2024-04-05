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
    private Image image;
    private Vector2 startPos;// стартовая позиция
    private GameObject form;
    public GameObject Form1;
    public GameObject Form2;
    public GameObject Form3;
    public GameObject Form4;
    public GameObject Form5;
    public GameObject Form6;//место назначения формы на уровне 
    public Text Title;
    

    private void Awake()
    {
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Title == Title.text)
            {
                metod(list[i].Place);
            }
        }
        

    }

    public void OnBeginDrag(PointerEventData eventData)//подняте 
    {
        image.raycastTarget = false;
        if (Title.text == list[^1].Title)
        {
            metod(6);
        }
        startPos = image.transform.position;
        

    }
    private void metod(int nomber)
    {
        print(nomber);
        if (nomber == 1)
            form = Form1;
        else if (nomber == 2) form = Form2;
        else if (nomber == 3) form = Form3;
        else if (nomber == 4) form = Form4;
        else if (nomber == 5) form = Form5;
        else if (nomber == 6) form = Form6;
    }

    public void OnDrag(PointerEventData eventData)// перемещение
    {
        recetTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)//опускание 
    {
        image.raycastTarget = true;
        Vector2 posObject = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;//определяет позицию объекта
        print (form.GetComponent<RectTransform>().anchoredPosition);
        Vector2 posForm = form.GetComponent<RectTransform>().anchoredPosition;

        if (MathF.Abs(posObject.x - posForm.x) <= 100f &&
            MathF.Abs(posObject.y - posForm.y) <= 100f)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//присоединение     


        }
        else
        {
            image.transform.position = startPos;// возвращение на место если условие не верно 

        }

    }

}
