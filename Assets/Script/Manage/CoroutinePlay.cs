using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePlay : MonoBehaviour
{
    public static CoroutinePlay instance;

    private void Awake()
    {
        instance = this;

    }

    public void coroutinePlay()
    {
        Fire.instance.fire_Play();
        MonsterSpawner.instance.monsterSpawn_Play();
        BloodSpawner.instance.bloodSpawn_Play();
    }
}
