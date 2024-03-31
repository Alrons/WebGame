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
    private Vector2 startPos;// стартовая позиция
    public GameObject form;//место назначения формы на уровне 
    //public GameObject level;

    private void Awake()
    {
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)//подняте 
    {

        image.raycastTarget = false;
        print(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
        startPos = image.transform.position;

    }

    public void OnDrag(PointerEventData eventData)// перемещение
    {
        recetTransform.anchoredPosition += eventData.delta;

    }

    public void OnEndDrag(PointerEventData eventData)//опускание 
    {

        image.raycastTarget = true;
        Vector2 posObject = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;//определяет позицию объекта


        if (MathF.Abs(posObject.x - form.transform.localPosition.x) <= 100f &&
            MathF.Abs(posObject.y - form.transform.localPosition.y) <= 100f)
        {
            //if (level.name == "level1")
            //{
            //    this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//присоединение            
            //}
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//присоединение     


        }
        else
        {
            image.transform.position = startPos;// возвращение на место если условие не верно 

        }

    }

}
