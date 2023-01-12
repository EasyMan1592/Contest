using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : Monster_Parents
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-30f, 30f));
    }

    void Update()
    {
        monster_Move();
    }

    protected override void monster_Move()
    {
        base.monster_Move();
    }
}