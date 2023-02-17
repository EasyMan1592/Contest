using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster_Parents
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") // 총알에 닿았을 때
        {

            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                OnDamage(bullet.bulletDamage);
            }

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player") // 플레이어 피격
        {
            GameManager.instance_.playerDamage(monster_contactDamage);
        }
    }

    public void Die__()
    {
        monster_HP = 0;
    }

    public static int a = 0;
    protected override void Die()
    {
        BossManager.instance_.boss[GameManager.instance_.stage].enabled = false;

        gameObject.GetComponent<Collider2D>().enabled = false;
        GameManager.instance_.blink(gameObject.GetComponent<Renderer>(), 3f);

        BossManager.instance_.bossClear();
        
        if(a == 0)
        {
            Invoke("setoff", 3f);
            a++;
        }
    }

    void setoff()
    {
        GameManager.instance_.scoreUp(monster_Score, transform);
        gameObject.SetActive(false);
        BossManager.instance_.bossHpBar_Obj.SetActive(false);
    }
}
