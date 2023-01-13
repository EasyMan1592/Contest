using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Monster_Parents
{
    void Start()
    {

    }

    void Update()
    {
        monster_Move();
    }

    protected override void Die()
    {
        base.Die();
    }

    protected override void monster_Move()
    {
        base.monster_Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
