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

    void Update()
    {
        if(GameManager.instance_.isGameover)
        {
            return;
        }


        if (!GameManager.instance_.stage1clear)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.x < 0f) pos.x = 0f;
            if (pos.x > 1f) pos.x = 1f;
            if (pos.y < 0f) pos.y = 0f;
            if (pos.y > 1f) pos.y = 1f;
            transform.position = Camera.main.ViewportToWorldPoint(pos);

            moveControl();
        }

        cutSceneMove();
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
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, 10), 0.01f);
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
