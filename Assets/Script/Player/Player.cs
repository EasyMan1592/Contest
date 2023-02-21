using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D playerRigid;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance_.isGameover)
        {
            return;
        }


        if (GameManager.instance_.stage1clear || GameManager.instance_.stage2clear)
        {
            cutSceneMove();

        }
        else
        {
            Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
            if (transform.position.x < -2.6f) pos = new Vector2 (-2.6f, transform.position.y);
            if (transform.position.x > 2.6f) pos = new Vector2 (2.6f, transform.position.y);
            if (transform.position.y < -4.8f) pos = new Vector2(transform.position.x, -4.8f);
            if (transform.position.y > 4.8f) pos = new Vector2(transform.position.x, 4.8f);
            transform.position = pos;

            moveControl();
        }
    }

    void moveControl()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;
        playerRigid.velocity = new Vector2(x, y);
    }

    // ÄÆ¾À ¿òÁ÷ÀÓ

    public void cutSceneMove()
    {
        if (GameManager.instance_.stage1clear)
        {
            playerRigid.velocity = Vector3.zero;
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, 10), 0.07f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.GetComponent<IItem>();
        if(item != null)
        {
            item.Use();
        }
    }
}
