using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Parents : MonoBehaviour
{
    public int monster_Score;
    public float monster_HP;
    public float monster_Speed;
    public float monster_Pain;
    public float monster_contactDamage;

    protected virtual void monster_Move()
    {
        transform.Translate(new Vector2(0, -1) * monster_Speed * Time.deltaTime);
    }

    public void OnDamage(float damage)
    {
        monster_HP -= damage;

        if (monster_HP <= 0)
        {
            GameManager.instance_.scoreUp(monster_Score, transform); // óġ �� ���ھ� ����
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") // �Ѿ˿� ����� ��
        {

            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if(bullet != null)
            {
                OnDamage(bullet.bulletDamage);
            }

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player") // �÷��̾� �ǰ�
        {
            if (GameManager.instance_.playerDamage(monster_contactDamage))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Deadzone") // ������ �浹, ��������� ����
        {
            GameManager.instance_.getPain(monster_Pain);
            Destroy(gameObject);
        }
    }
}
