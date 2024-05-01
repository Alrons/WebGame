using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEditor.Tilemaps;


public class SpawnPlaseFD : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Canvas;
    public Text ForLine;
    private int Number;

    DataBase DB =  new DataBase();
    public void Awake()
    {
        StartCoroutine(DB.GetItems());
        StartCoroutine(DB.GetSize());
    }

    void Start()
    {
       
        Number = 1;
        float x = (float)(Prefab.transform.position.x * -1.5);
        float y = (float)(Prefab.transform.position.y * -0.8);

        for (int i = 0; i < DataBase.GetCountLine(); i++)
        {
            
            SpawnObject spawnObject = new SpawnObject();
            int l = 0;
            for (int j = 0; j < DataBase.GetCountColum(); j++)
            {
                GameObjId.PrefabFD.Add(new GameObjId(spawnObject.CopyPref(Prefab, new Vector2(Prefab.transform.position.x + x * j, Prefab.transform.position.y + y * i), Canvas), Number));
                Number += 1;
            
                l = j + 1;
            }
            var spawn = Instantiate(ForLine, new Vector3(Prefab.transform.position.x + x * l, Prefab.transform.position.y + y * i, Prefab.transform.position.z), Quaternion.identity);
            spawn.transform.SetParent(Canvas.transform);
            spawn.transform.localScale = new Vector3(1, 1, 1);
            GameObjId.LinePower.Add(new GameObjId(spawn, i));


        }

        Destroy(Prefab);
    }

}
