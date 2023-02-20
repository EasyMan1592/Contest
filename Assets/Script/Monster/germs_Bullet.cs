using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germs_Bullet : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;

    [SerializeField] float speed;
    [SerializeField] int bulletDamage;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);

        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;

        dir = playerTransform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // 플레이어 피격
        {
            if(GameManager.instance_.playerDamage(bulletDamage))
            {
                Destroy(gameObject);
            }
        }
    }
}
