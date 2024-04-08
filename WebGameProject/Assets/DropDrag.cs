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
    private Image image;// Картинка с префаба 
    private Vector2 startPos;// стартовая позиция
    private GameObject form;// общая переменная в которую мы будем назначать место для большего удобства
    public GameObject Form1;//место куда мы будем вставлять форму
    public GameObject Form2;//место куда мы будем вставлять форму
    public GameObject Form3;//место куда мы будем вставлять форму
    public GameObject Form4;//место куда мы будем вставлять форму
    public GameObject Form5;//место куда мы будем вставлять форму
    public GameObject Form6;//место куда мы будем вставлять форму 
    public Text Title;//Тайтл основного префаба 
    public Text price;//Цена основоного префаба 
    public Transform Context;//Мусор
    private string FailBy;//Просто для запоменания 

    private void Awake()
    {
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        // Перебераем список (без последнего значения) и сравниваем тайтлы (который в списке и в префабе), в зависимости то этого распределяем места которые берем из списка 
        for (int i = 0; i < list.Count; i++)
        {
            // Сравниваем тайтлы
            if (list[i].Title == Title.text)
            {
                // Берем из списка номер места и передаем в метот, где мы берем коардинаты из этого места
                metod(list[i].Place);
            }
        }
        

    }

    public void OnBeginDrag(PointerEventData eventData)//подняте 
    {
        image.raycastTarget = false;

        // Берем последнее значение из списка и сравниваем 2 тайтла, который в списке и который в префабе если совпадает, то выбираем место 6
        if (Title.text == list[^1].Title)
        {
            metod(6);
        }
        startPos = image.transform.position; // Берем коарденаты изначальной позиций и запоминаем
        

    }

    // Метод в котором мы решаем из какой площядки будем брать коарденаты, понадобится для дальнейшего перетаскивания 
    private void metod(int nomber)
    {
        print(nomber);
        if (nomber == 1)  // Если место 1 то берем данные из места 1
            form = Form1;
        else if (nomber == 2) form = Form2; // Если место 2 то берем данные из места 2 
        else if (nomber == 3) form = Form3; // Если место 3 то берем данные из места 3 
        else if (nomber == 4) form = Form4; // Если место 4 то берем данные из места 4 
        else if (nomber == 5) form = Form5; // Если место 5 то берем данные из места 5 
        else if (nomber == 6) form = Form6; // Если место 6 то берем данные из места 6 
    }

    public void OnDrag(PointerEventData eventData)// перемещение 
    {
        recetTransform.anchoredPosition += eventData.delta; 
    }

    // Метод в которо мы ждем 2 секунды и возращаем Тайтл обратно 
    private IEnumerator RetarnTitle()
    {
        yield return new WaitForSeconds(2);
        Title.text = FailBy;
    }
    public void OnEndDrag(PointerEventData eventData)//опускание 
    {
        image.raycastTarget = true;
        Vector2 posObject = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;//определяет позицию объекта
        print (form.GetComponent<RectTransform>().anchoredPosition); // Просто надо

        //Берем позицию места в которое будем вставлять
        Vector2 posForm = form.GetComponent<RectTransform>().anchoredPosition;

        // Математика 
        if (MathF.Abs(posObject.x - posForm.x) <= 100f &&
            MathF.Abs(posObject.y - posForm.y) <= 100f)//Тут ряльна математика
        {
            // Вычитаем цену из банка
            if (int.Parse(price.text) <= coins)
            {
                this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//присоединение к позициям
                coins = coins - int.Parse(price.text);// Вычитаем из банка

            }

            //Если цена больше чем есть в банке мы на 2 секунды меняем таитл на ДЕНЬГИ ГДЕ!
            else
            {
                image.transform.position = startPos;// возвращение на место если условие не верно
                FailBy = Title.text;//Сохраняем текс в переменную
                Title.text = "Деньги где!";// Зазменяем текст тайтла
                StartCoroutine(RetarnTitle());// Переход на метод в котором стоит таимер на 2 секунды и возращяем значение 

            }
                                                                                                      


        }
        else
        {
            image.transform.position = startPos;// возвращение на место если условие не верно 

        }

    }

}
