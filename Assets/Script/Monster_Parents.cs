using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Parents : MonoBehaviour
{
    public int monster_HP;
    public int monster_Speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            monster_HP--;

            Destroy(collision.gameObject);

            if (monster_HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    protected virtual void monster_Move()
    {
        transform.Translate(new Vector2(0, -monster_Speed * Time.deltaTime));
    }
}
