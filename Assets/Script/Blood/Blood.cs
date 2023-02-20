using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] int key;
    [SerializeField] bool isDie;
    private Rigidbody2D rigid;
    private CircleCollider2D colli;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        colli = GetComponent<CircleCollider2D>();

        isDie = false;

        key = Random.Range(0, 2);
        if(key == 0)
        {
            key = -1;
        }

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        move();
    }

    void move()
    {
        if(!isDie)
        {
            rigid.velocity = new Vector2(key * xSpeed, -ySpeed);
        }
        else
        {
            rigid.velocity = new Vector2(key * 6, 0);
        }
       
    }

    protected virtual void die()
    {
        colli.enabled = false;
        isDie = true;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            key *= -1;
        }
    }
}
