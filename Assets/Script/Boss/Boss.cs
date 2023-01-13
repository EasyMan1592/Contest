using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster_Parents
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") // �Ѿ˿� ����� ��
        {

            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                OnDamage(bullet.bulletDamage);
                BossManager.instance_.bossUIUpdate();
            }

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player") // �÷��̾� �ǰ�
        {
            GameManager.instance_.playerDamage(monster_contactDamage);
        }
    }
}
