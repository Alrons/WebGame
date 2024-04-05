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
    

    private void Awake()
    {
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)//подняте 
    {

        image.raycastTarget = false;
        
        startPos = image.transform.position;

    }

    public void OnDrag(PointerEventData eventData)// перемещение
    {
        recetTransform.anchoredPosition += eventData.delta;
        print(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);

    }

    public void OnEndDrag(PointerEventData eventData)//опускание 
    {

        image.raycastTarget = true;
        Vector2 posObject = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;//определяет позицию объекта
        Vector2 pos  = image.transform.position;
        Vector2 posForm =form.GetComponent<RectTransform>().anchoredPosition;

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
