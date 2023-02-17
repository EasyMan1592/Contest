using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : Monster_Parents
{

    public Transform playerTransform;
    Vector3 dir;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        dir = playerTransform.position - transform.position;
        transform.rotation = Quaternion.Euler(0f, 0f, playerTransform.position.normalized.z);
    }

    void Update()
    {
        monster_Move();
    }

    protected override void Die()
    {
        base.Die();
    }

    protected override void monster_Move()
    {
        transform.position += dir* monster_Speed * Time.deltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
