using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] int bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // 플레이어 피격
        {
            if (GameManager.instance_.playerDamage(bulletDamage))
            {
                Destroy(gameObject);
            }
        }
    }
}
