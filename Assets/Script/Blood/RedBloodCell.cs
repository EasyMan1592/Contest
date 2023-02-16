using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : Blood
{
    [SerializeField] float Damage;

    protected override void die()
    {
        base.die();
        
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("MonsterBullet") || collision.gameObject.CompareTag("Monster") )
        {
            die();
            GameManager.instance_.getPain(Damage);
        }
        else if(collision.gameObject.CompareTag("Bullet"))
        {
            die();
        }
    }
}
