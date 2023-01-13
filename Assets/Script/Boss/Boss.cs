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

    protected override void Die()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        GameManager.instance_.blink(gameObject.GetComponent<Renderer>(), 3f);
        Invoke("setoff", 3f);
    }

    void setoff()
    {
        gameObject.SetActive(false);
        BossManager.instance_.bossHpBar_Obj.SetActive(false);
    }

    
}
