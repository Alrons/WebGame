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
    private Image image;// Картинка с префаба 
    private Vector2 startPos;// стартовая позиция
    private GameObject form;// общая переменная в которую мы будем назначать место для большего удобства

    public GameObject dragObject; // наш объект
    
    public Text Title;//Тайтл основного префаба 
    public Text price;//Цена основоного префаба 
    public Text Health;
    public Text Power;
    public Text XPower;
    public ScrollRect scrollRect;
    public Text IdRevard;
    // Переменные с которыми будет проходить математика
    private int BackPrice; //цена блока
    private int BackHealth;
    private double BackPower;
    private double BackXPower;
    private int Place;

    public Transform Context;//Мусор
    private string FailBy;//Просто для запоменания 


    private bool posNow;
    private int BackCurrency;

    DataBase DB = new DataBase();
    
    void Start()
    {
        
        recetTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        // Перебераем список (без последнего значения) и сравниваем тайтлы (который в списке и в префабе), в зависимости то этого распределяем места которые берем из списка 
        for (int i = 0; i < GameObjId.GameObjects.Count; i++)
        {
            // Сравниваем тайтлы
            if (GameObjId.GameObjects[i].GameObject == dragObject)
            {
                
                // Берем из списка номер места и передаем в метот, где мы берем коардинаты из этого места
                FindForm(ClassOfItem.list[i].Place);
                BackPrice = ClassOfItem.list[i].Price;
                BackHealth = ClassOfItem.list[i].Health;
                BackPower = ClassOfItem.list[i].Power;
                BackXPower = ClassOfItem.list[i].XPover;
                BackCurrency = ClassOfItem.list[i].Сurrency;
                Place = ClassOfItem.list[i].Place;
            }
        }
        // Берем последнее значение из списка и сравниваем 2 тайтла, который в списке и который в префабе если совпадает, то выбираем место 6
        
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
    public void OnBeginDrag(PointerEventData eventData)//подняте 
    {

        if (dragObject == GameObjId.GameObjects[^1].GameObject)
        {
            FindForm(ClassOfItem.list[^1].Place);
            BackPrice = ClassOfItem.list[^1].Price;
            BackHealth = ClassOfItem.list[^1].Health;
            BackPower = ClassOfItem.list[^1].Power;
            BackXPower = ClassOfItem.list[^1].XPover;
            BackCurrency = ClassOfItem.list[^1].Сurrency;
            Place = ClassOfItem.list[^1].Place;
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
            //Если цена на картинке меньше чем в коде
            
        }
        else
        {
            this.transform.position = startPos ;// возвращение на место если условие не верно 
            form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.1f);//подсветка

        }


    }
    
    private void MassagaIfAdded(string ChangeTitle)
    {
        form.GetComponent<Image>().color = new Color(255f, 0f, 0f, 0.5f);
        this.transform.position = startPos;// возвращение на место если условие не верно
        FailBy = Title.text;//Сохраняем текст в переменную
        Title.text = ChangeTitle;// Заменяем текст тайтла
        StartCoroutine(RetarnTitle());// Переход на метод в котором стоит таимер на 2 секунды и возращяем значение 
    }

    public int Buy(int BackPrice, int coins)
    {
        if (BackPrice <= coins)
        {
            form.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);//подсветка
            AddedPrefab addedPrefab = new AddedPrefab();
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);//присоединение к позициям
            
           
            if (addedPrefab.CheckIfAdded(Place))
            {

                MassagaIfAdded("Место уже занято!");

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
                //Добовляем в список в котором хранятся добавленные предметы
                AddedPrefab.Added.Add(new AddedPrefab(Place, spawnObject.CopyPref(this.dragObject, this.transform.position, form.transform), BackHealth, BackPower, BackXPower));
                
                Destroy(this.dragObject); // Унечтожаем объект который мы копировали 

            }


          
        }
        //Если цена больше чем есть в банке мы на 2 секунды меняем таитл на ДЕНЬГИ ГДЕ!
        else
        {
            MassagaIfAdded("Деньги где!");

        }
         return coins = coins - BackPrice;// Вычитаем из банка
    }

}

