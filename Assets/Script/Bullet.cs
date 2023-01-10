using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D bulletRigid;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigid = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = speed * Time.deltaTime;
        transform.Translate(new Vector2(0, moveY));
    }

}
