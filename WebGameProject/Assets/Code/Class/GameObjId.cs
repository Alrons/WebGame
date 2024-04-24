using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class GameObjId
{
    public GameObject GameObject { get; }
    public Text Text { get; set; }
    public int count { get; }
    public double Power { get; set; }



    public static List<GameObjId> GameObjects = new List<GameObjId>();
    // для мест куда вставляем
    public static List<GameObjId> PrefabFD = new List<GameObjId>();
    // для подсчета сил в строку
    public static List<GameObjId> LinePower = new List<GameObjId>();

    public GameObjId (GameObject gameObject, int count)
    {
        this.GameObject = gameObject;
        this.count = count;
    }
    public GameObjId (Text text, int count)
    {
        this.Text = text;
        this.count = count;
        this.Power = 0;
    }
}
