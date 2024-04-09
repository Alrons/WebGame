using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ClassOfItem;
using static DropDrag;
using static GameObjId;
public class SpawnObject : MonoBehaviour
{
    public GameObject Box;
    public float TimeSpawn;
    public Transform CanvasObject;
    public Text Title;
    public Text Price;
    public Text Description;
    public Text Health;
    public Text Power;
    public Text XPower;
    int count;

    public static GameObject CopyPref(GameObject box, Vector3 position, Transform setparent)
    {
        var spawn = Instantiate(box, position, Quaternion.identity);
        spawn.transform.SetParent(setparent.transform);
        spawn.transform.localScale = new Vector3(1, 1, 1);

        return spawn;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Заполняем список 
        // string title, string description, int price, string Image, int place, int Health, double Power, double XPover
        list.Add(new ClassOfItem("Title1", "describtion1", 100, "Path", 4, 150, 15, 1.1));
        list.Add(new ClassOfItem("Title2", "describtion2", 900, "Path", 3, 130, 16, 1.2));
        list.Add(new ClassOfItem("Title3", "describtion3", 500, "Path", 2, 120, 17, 1.3));
        list.Add(new ClassOfItem("Title3", "describtion3", 500, "Path", 2, 160, 20, 1.6));
        list.Add(new ClassOfItem("Title4", "describtion4", 150, "Path", 1, 110, 18, 1.4));
        list.Add(new ClassOfItem("Title5", "describtion5", 200, "Path", 2, 140, 19, 1.5));
        list.Add(new ClassOfItem("Title4", "describtion4", 150, "Path", 1, 170, 21, 1.7));
        list.Add(new ClassOfItem("Title5", "describtion5", 200, "Path", 2, 180, 22, 1.8));

        // Указываем изначальное колличество цены
        coins = 1000;
        
        StartCoroutine(SpawnCD());
        
        
    }
    private void ChangePref(string title, int price, string description, int health, double power, double xpower)
    {
        Title.text = title;
        Price.text = String.Format("{0}", price);
        Description.text = description;
        Health.text = String.Format("{0}", health);
        Power.text = String.Format("{0}", power);
        XPower.text = String.Format("{0}", xpower);
    }
    
    private void Repeat()
    {
        // Для повторения SpawnCD()
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD()
    {   // Если надо не спешное появление префабов 
        yield return new WaitForSeconds(TimeSpawn);
  
        if (count != list.Count-1)

        {   // Изменяем изначальный преаб
            ChangePref(list[count].Title, list[count].Price, list[count].Description, list[count].Health, list[count].Power, list[count].XPover);
            // Копируем префаб
            var gameobj = CopyPref(Box, Box.transform.position, CanvasObject);

            GameObjects.Add(new GameObjId(gameobj, count));
            // Повторяем
            Repeat();
            count++;
        }
        else
        {
            GameObjects.Add(new GameObjId(Box, count));
            // Если список подходит ко последнему значению, мы изменяем оригинальный префаб
            ChangePref(list[count].Title, list[count].Price, list[count].Description, list[count].Health, list[count].Power, list[count].XPover);
        }
        

    }
}
