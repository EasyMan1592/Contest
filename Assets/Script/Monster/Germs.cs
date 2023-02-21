using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germs : Monster_Parents
{
    private GameObject player;
    public Transform playerTransform;
    public GameObject germs_BulletPrefab;

    [SerializeField] float keyChangeTime;
    [SerializeField] float dashTime;
    [SerializeField] float dashForce;
    [SerializeField] bool dash;
    [SerializeField] float delayTime;
    [SerializeField] float fireTime;
    [SerializeField] int key;

    Vector3 dir;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;

        dash = false;
        key = Random.Range(0, 2);
        if (key == 0)
        {
            key = -1;
        }
        StartCoroutine(Grems_Dash());
        StartCoroutine(fire_Delay());
    }

    void FixedUpdate()
    {
        if (!stop)
        {
            if (!dash)
            {
                Grems_Move();
                dir = playerTransform.position - transform.position;
            }
            else
            {
                transform.position += dir * dashForce * Time.deltaTime;
            }
        }
    }

    void Grems_Move()
    {
        if (!stop)
        {
            if (transform.position.y > 0.6)
            {
                transform.Translate(new Vector2(-1 * key, -0.3f) * monster_Speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector2(-1 * key, 0) * monster_Speed * Time.deltaTime);
            }
        }
    }

    IEnumerator fire_Delay()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        if (!stop)
        {
            yield return new WaitForSecondsRealtime(keyChangeTime);

            for (int i = 0; i < 3; i++)
            {
                Instantiate(germs_BulletPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSecondsRealtime(fireTime);
            }
            StartCoroutine(Fire());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Monster"))
        {
            key *= -1;
        }

        if (collision.gameObject.tag == "Deadzone") // 데드존 충돌, 고통게이지 증가
        {
            GameManager.instance_.getPain(monster_Pain);
            Destroy(gameObject);
        }
    }

    IEnumerator Grems_Dash()
    {
        yield return new WaitForSecondsRealtime(dashTime);
        dash = true;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void Die()
    {
        base.Die();
    }

}
