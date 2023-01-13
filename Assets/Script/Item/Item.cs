using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid= GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        rigid.velocity = new Vector2(0, -speed);
    }


}

