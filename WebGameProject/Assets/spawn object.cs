using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ClassOfItem;
public class spawnobject : MonoBehaviour
{
    public GameObject Box;
    public float TimeSpawn;
    public Transform CanvasObject;
    public Text Title;
    public Text Price;
    public Text Description;
    int count;

    //Создаем публичный список к которому будем обращяться из других фаилов
    public static List<ClassOfItem> list = new List<ClassOfItem>();

    // здесь храним цену
    static public int coins; 

    // Start is called before the first frame update
    void Start()
    {
        // Заполняем список 
        // string title, string description, int price, string Image, int place, int Health, double Power, double XPover
        list.Add(new ClassOfItem("Title1", "describtion1", 100, "Path",4,150,15,1.1));
        list.Add(new ClassOfItem("Title2", "describtion2", 900, "Path", 3, 130, 16, 1.2));
        list.Add(new ClassOfItem("Title3", "describtion3", 500, "Path", 2, 120, 17, 1.3));
        list.Add(new ClassOfItem("Title4", "describtion4", 150, "Path",1, 110, 18, 1.4));
        list.Add(new ClassOfItem("Title5", "describtion5", 200, "Path",2, 140, 19, 1.5));
        list.Add(new ClassOfItem("Title3", "describtion3", 500, "Path", 2, 160, 20, 1.6));
        list.Add(new ClassOfItem("Title4", "describtion4", 150, "Path", 1, 170, 21, 1.7));
        list.Add(new ClassOfItem("Title5", "describtion5", 200, "Path", 2, 180, 22, 1.8));

        // Указываем изначальное колличество цены
        coins = 1000;
        
        StartCoroutine(SpawnCD());
        
        
    }
    void Repeat()
    {
        // Для повторения SpawnCD()
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(TimeSpawn);
  
        if (count != list.Count-1)

        {   // Изменяем изначальный преаб
            Title.text = list[count].Title;
            Price.text = String.Format("{0}",list[count].Price);
            Description.text = list[count].Description;

            // Копируем префаб
            var spawn = Instantiate(Box, Box.transform.position, Quaternion.identity);
            spawn.transform.SetParent(CanvasObject.transform);
            spawn.transform.localScale = new Vector3(1, 1, 1);
 
            // Повторяем
            Repeat();
            count++;
        }
        else
        {
            // Если список подходит ко последнему значению, мы изменяем оригинальный префаб
            Title.text = list[count].Title;
            Price.text = String.Format("{0}", list[count].Price);
            Description.text = list[count].Description;
        }
        

    }
}
