using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : Monster_Parents
{
    public GameObject cancerAttackArea;

    [SerializeField]
    private float sizeUpSpeed;

    void Update()
    {
        monster_Move();
        Cancer_Attack();
    }

    void Cancer_Attack()
    {
        float scale = cancerAttackArea.transform.localScale.x + Time.deltaTime * sizeUpSpeed;
        cancerAttackArea.transform.localScale = new Vector2(scale, scale);
    }

    protected override void Die()
    {
        base.Die();
    }

    protected override void monster_Move()
    {
        base.monster_Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
