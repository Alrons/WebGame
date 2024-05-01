using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




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

    public GameObject CopyPref(GameObject box, Vector3 position, Transform setparent)
    {
        var spawn = Instantiate(box, position, Quaternion.identity);
        spawn.transform.SetParent(setparent.transform);
        spawn.transform.localScale = new Vector3(1, 1, 1);
        
        return spawn;
        
    }

   
    void Start()    {     
        
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

        
        if (count != ClassOfItem.list.Count-1)

        {   // �������� ����������� �����
            ChangePref(ClassOfItem.list[count].Title, ClassOfItem.list[count].Price, ClassOfItem.list[count].Description, ClassOfItem.list[count].Health, ClassOfItem.list[count].Power, ClassOfItem.list[count].XPover);
            // �������� ������
            var gameobj = CopyPref(Box, Box.transform.position, CanvasObject);

            GameObjId.GameObjects.Add(new GameObjId(gameobj, count));
            // ���������
            Repeat();
            count++;
        }
        else
        {
            GameObjId.GameObjects.Add(new GameObjId(Box, count));
            // ���� ������ �������� �� ���������� ��������, �� �������� ������������ ������
            ChangePref(ClassOfItem.list[count].Title, ClassOfItem.list[count].Price, ClassOfItem.list[count].Description, ClassOfItem.list[count].Health, ClassOfItem.list[count].Power, ClassOfItem.list[count].XPover);
        }
        

    }
}
