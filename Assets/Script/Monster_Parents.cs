using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Parents : MonoBehaviour
{
    public int monster_HP;
    public int monster_Speed;
    public int monster_Damage;
    public int monster_Score;
    public int monster_Pain;
    public int monster_contactDamage;
    

    protected virtual void monster_Move()
    {
        transform.Translate(new Vector2(0, -monster_Speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet") // 총알에 닿았을 때
        {
            monster_HP--;

            Destroy(collision.gameObject);

            if (monster_HP <= 0)
            {
                GameManager.instance_.scoreUp(monster_Score); // 처치 시 스코어 증가
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Player") // 플레이어 피격
        {
            GameManager.instance_.playerDamage(monster_contactDamage);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Deadzone") // 데드존 충돌, 고통게이지 증가
        {
            GameManager.instance_.getPain(monster_Pain);
            Destroy(gameObject);
        }


    }
}
