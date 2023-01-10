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
        if(collision.gameObject.tag == "Bullet") // �Ѿ˿� ����� ��
        {
            monster_HP--;

            Destroy(collision.gameObject);

            if (monster_HP <= 0)
            {
                GameManager.instance_.scoreUp(monster_Score); // óġ �� ���ھ� ����
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Player") // �÷��̾� �ǰ�
        {
            GameManager.instance_.playerDamage(monster_contactDamage);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Deadzone") // ������ �浹, ��������� ����
        {
            GameManager.instance_.getPain(monster_Pain);
            Destroy(gameObject);
        }


    }
}
