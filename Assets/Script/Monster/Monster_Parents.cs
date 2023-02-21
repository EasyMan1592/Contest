using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster_Parents : MonoBehaviour
{
    public int monster_Score;
    public float monster_HP;
    public float monster_Speed;
    public float monster_Pain;
    public float monster_contactDamage;
    public bool stop;


    protected virtual void monster_Move()
    {
        if (!stop)
        {
            transform.Translate(new Vector2(0, -1) * monster_Speed * Time.deltaTime);
        }
    }

    public void OnDamage(float damage)
    {
        monster_HP -= damage;

        if (monster_HP <= 0)
        {
            
            Die();
        }
    }

    protected virtual void Die()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        stop = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSecondsRealtime(0.1f);
        Destroy(gameObject);
        GameManager.instance_.scoreUp(monster_Score, transform);
    }



    public void Die_()
    {
        Die();
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
