using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germs : Monster_Parents
{
    void Start()
    {
        
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
