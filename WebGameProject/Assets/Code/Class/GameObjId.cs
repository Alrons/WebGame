using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GameObjId
{
    public GameObject GameObject { get; }
    public int count { get; }

    public static List<GameObjId> GameObjects = new List<GameObjId>();
    
    public GameObjId (GameObject gameObject, int count)
    {
        this.GameObject = gameObject;
        this.count = count;
    }
}
