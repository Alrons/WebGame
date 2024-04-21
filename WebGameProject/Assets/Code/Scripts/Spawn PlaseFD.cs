using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static SpawnObject;
using static GameObjId;
using UnityEditor.Tilemaps;

public class SpawnPlaseFD : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Canvas;
    public Text ForLine;
    public static int CountColum;
    public static int CountLine;
    private int Number;

    void Start()
    {
        // Колличество колонок
        CountColum = 3;
        // Количество линий
        CountLine = 4;
        // Переменная которая передает в список номер копированного элемента 
        Number = 1;
        float x = Prefab.transform.position.x * -1;
        float y = (float)(Prefab.transform.position.y * -0.5);

        for (int i = 0; i < CountLine; i++)
        {
            int l = 0;
            for (int j = 0; j < CountColum; j++)
            {
                PrefabFD.Add(new GameObjId(CopyPref(Prefab, new Vector2(Prefab.transform.position.x + x * j, Prefab.transform.position.y + y * i), Canvas), Number));
                Number += 1;
            
                l = j + 1;
            }
            var spawn = Instantiate(ForLine, new Vector3(Prefab.transform.position.x + x * l, Prefab.transform.position.y + y * i, Prefab.transform.position.z), Quaternion.identity);
            spawn.transform.SetParent(Canvas.transform);
            spawn.transform.localScale = new Vector3(1, 1, 1);
            LinePower.Add(new GameObjId(spawn, i));


        }

        Destroy(Prefab);
    }

}
