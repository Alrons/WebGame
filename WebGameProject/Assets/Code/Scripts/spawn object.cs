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
        // ��������� ������ 
        // string title, string description, int price, string Image, int place, int Health, double Power, double XPover
        

        // ��������� ����������� ����������� ����
        coins = 10000;
        
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
        // ��� ���������� SpawnCD()
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD()
    {   // ���� ���� �� ������� ��������� �������� 
        yield return new WaitForSeconds(TimeSpawn);
  
        if (count != list.Count-1)

        {   // �������� ����������� �����
            ChangePref(list[count].Title, list[count].Price, list[count].Description, list[count].Health, list[count].Power, list[count].XPover);
            // �������� ������
            var gameobj = CopyPref(Box, Box.transform.position, CanvasObject);

            GameObjects.Add(new GameObjId(gameobj, count));
            // ���������
            Repeat();
            count++;
        }
        else
        {
            GameObjects.Add(new GameObjId(Box, count));
            // ���� ������ �������� �� ���������� ��������, �� �������� ������������ ������
            ChangePref(list[count].Title, list[count].Price, list[count].Description, list[count].Health, list[count].Power, list[count].XPover);
        }
        

    }
}
