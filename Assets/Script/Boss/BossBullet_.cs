using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet_ : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] int bulletDamage;
    int key;

    // Start is called before the first frame update
    void Start()
    {
        key = Random.Range(0, 2);
        if (key == 0)
        {
            key = -1;
        }
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(key, 1) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            key *= -1;
        }

        if (collision.gameObject.tag == "Player") // 플레이어 피격
        {
            if (GameManager.instance_.playerDamage(bulletDamage))
            {
                Destroy(gameObject);
            }
        }
    }
}
