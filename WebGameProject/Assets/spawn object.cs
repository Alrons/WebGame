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
    public static List<ClassOfItem> list = new List<ClassOfItem>();
    static public int coins; 

    // Start is called before the first frame update
    void Start()
    {
        list.Add(new ClassOfItem("Title1", "describtion1", 100, "Path",4));
        list.Add(new ClassOfItem("Title2", "describtion2", 900, "Path", 3));
        list.Add(new ClassOfItem("Title3", "describtion3", 500, "Path", 2));
        list.Add(new ClassOfItem("Title4", "describtion4", 150, "Path",1));
        list.Add(new ClassOfItem("Title5", "describtion5", 200, "Path",2));
        coins = 1000;
        
        StartCoroutine(SpawnCD());
        
        
    }
    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(TimeSpawn);
        // задаем парента
        if (count != list.Count-1)
        {
            Title.text = list[count].Title;
            Price.text = String.Format("{0}",list[count].Price);
            Description.text = list[count].Description;

            var spawn = Instantiate(Box, Box.transform.position, Quaternion.identity);
            spawn.transform.SetParent(CanvasObject.transform);
            spawn.transform.localScale = new Vector3(1, 1, 1);
 
            
            Repeat();
            count++;
        }
        else
        {
            Title.text = list[count].Title;
            Price.text = String.Format("{0}", list[count].Price);
            Description.text = list[count].Description;
        }
        

    }
}
