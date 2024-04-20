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
using Unity.VisualScripting;


public class DropDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    private RectTransform recetTransform;
    private Image image;// Картинка с префаба 
    private Vector2 startPos;// стартовая позиция
    private GameObject form;// общая переменная в которую мы будем назначать место для большего удобства

    public GameObject dragObject; // наш объект
 
    public GameObject Form1;//место куда мы будем вставлять форму
    public GameObject Form2;//место куда мы будем вставлять форму
    public GameObject Form3;//место куда мы будем вставлять форму
    public GameObject Form4;//место куда мы будем вставлять форму
    public GameObject Form5;//место куда мы будем вставлять форму
    public GameObject Form6;//место куда мы будем вставлять форму 

    public Text Title;//Тайтл основного префаба 
    public Text price;//Цена основоного префаба 
    public Text Health;
    public Text Power;
    public Text XPower;
    public ScrollRect scrollRect;

    // Переменные с которыми будет проходить математика
    private int BackPrice; //цена блока
    private int BackHealth;
    private double BackPower;
    private double BackXPower;
    private int Place;

    public Transform Context;//Мусор
    private string FailBy;//Просто для запоменания 


    private bool posNow;




    void Start()
    {
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        // Перебераем список (без последнего значения) и сравниваем тайтлы (который в списке и в префабе), в зависимости то этого распределяем места которые берем из списка 
        for (int i = 0; i < GameObjects.Count; i++)
        {
            // Сравниваем тайтлы
            if (GameObjects[i].GameObject == dragObject)
            {
                // Берем из списка номер места и передаем в метот, где мы берем коардинаты из этого места
                FindForm(list[i].Place);
                BackPrice = list[i].Price;
                BackHealth = list[i].Health;
                BackPower = list[i].Power;
                BackXPower = list[i].XPover;
            }
        }
        // Берем последнее значение из списка и сравниваем 2 тайтла, который в списке и который в префабе если совпадает, то выбираем место 6
        
    }
    private void FindForm(int nomber)
    {
        Place = nomber;
        if (nomber == 1) form = Form1; //      Если место 1 то берем данные из места 1
        else if (nomber == 2) form = Form2; // Если место 2 то берем данные из места 2 
        else if (nomber == 3) form = Form3; // Если место 3 то берем данные из места 3 
        else if (nomber == 4) form = Form4; // Если место 4 то берем данные из места 4 
        else if (nomber == 5) form = Form5; // Если место 5 то берем данные из места 5 
        else if (nomber == 6) form = Form6; // Если место 6 то берем данные из места 6 
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
    public void OnBeginDrag(PointerEventData eventData)//подняте 
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
        startPos = image.transform.position; // Берем коарденаты изначальной позиций и запоминаем
        form.GetComponent<Image>().color = new Color(255f,255f,255f,0.3f);//подсветка

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
        form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.1f);//подсветка
    }

    //нужны перменные в метод BackPrice, coins*, posNow

    public void OnEndDrag(PointerEventData eventData)//опускание 
    {
        scrollRect.vertical = true;
        image.raycastTarget = true;



        if (posNow)
        {
            // Если цена на картинке меньше чем в коде 
            Buy(BackPrice, CoinsOnebank);
            
        }
        else
        {
            this.transform.position = startPos ;// возвращение на место если условие не верно 
            form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.1f);//подсветка

        }

    }
   
    public void Buy(int BackPrice, int coins)
    {
        if (BackPrice <= coins)
        {
            AddedPrefab addedPrefab = new AddedPrefab();
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//присоединение к позициям

            form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);//подсветка
            if (addedPrefab.CheckIfAdded(Place))
            {

                addedPrefab.Updating(BackHealth, BackXPower, Place);
                CountsUpdate.Add(1);
                Destroy(dragObject);

            }
            else
            {
                CountsUpdate.Add(1);
                //Добовляем в список в котором хранятся добавленные предметы
                Added.Add(new AddedPrefab(Place, CopyPref(this.dragObject, this.transform.position, form.transform), BackHealth, BackPower, BackXPower));
                Destroy(this.dragObject); // Унечтожаем объект который мы копировали 
            }


            coins = coins - BackPrice;// Вычитаем из банка
        }
        //Если цена больше чем есть в банке мы на 2 секунды меняем таитл на ДЕНЬГИ ГДЕ!
        else
        {
            form.GetComponent<Image>().color = new Color(255f, 0f, 0f, 0.5f);
            this.transform.position = startPos;// возвращение на место если условие не верно
            FailBy = Title.text;//Сохраняем текст в переменную
            Title.text = "Деньги где!";// Заменяем текст тайтла
            StartCoroutine(RetarnTitle());// Переход на метод в котором стоит таимер на 2 секунды и возращяем значение 

        }
    }

}

