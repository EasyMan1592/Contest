using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

    void Update()
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

    void Grems_Move()
    {
        transform.Translate(new Vector2(-monster_Speed * key * Time.deltaTime, 0));
    }

    IEnumerator fire_Delay()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        yield return new WaitForSecondsRealtime(keyChangeTime);

        for(int i = 0; i < 3; i++)
        {
            Instantiate(germs_BulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(fireTime);
        }
        StartCoroutine(Fire());
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

}
