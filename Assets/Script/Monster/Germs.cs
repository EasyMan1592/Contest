using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Germs : Monster_Parents
{
    private GameObject player;
    public Transform playerTransform;
    public GameObject germs_BulletPrefab;


    [SerializeField] int key;
    [SerializeField] float keyChangeTime;
    [SerializeField] float dashTime;
    [SerializeField] float dashForce;
    [SerializeField] bool dash;
    [SerializeField] float delayTime;
    [SerializeField] float fireTime;

    Vector3 dir;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;

        dash = false;
        key = 1;
        //key = Random.Range(0,2);
        //if (key == 0)
        //{
        //    key = -1;   
        //}

        StartCoroutine(keyChange());
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


    IEnumerator keyChange()
    {
        yield return new WaitForSecondsRealtime(keyChangeTime);
        key *= -1;
        StartCoroutine(keyChange());
    }

    IEnumerator Grems_Dash()
    {
        yield return new WaitForSecondsRealtime(dashTime);
        dash = true;
    }

}
