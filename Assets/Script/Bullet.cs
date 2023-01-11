using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public float bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = speed * Time.deltaTime;
        transform.Translate(new Vector2(0, moveY));
    }

}
