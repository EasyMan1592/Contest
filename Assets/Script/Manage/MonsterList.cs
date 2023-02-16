using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterList : MonoBehaviour
{
    public static MonsterList instance;
    private void Awake()
    {
        instance = this; 
    }

    public List<GameObject> monsters = new List<GameObject>();
}
