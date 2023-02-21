using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : Monster_Parents
{
    public GameObject cancerAttackArea;
    public CircleCollider2D cancerAttackArea_cancerCollider;

    [SerializeField] float sizeUpSpeed;

    [SerializeField] float elapsedTime;
    [SerializeField] float blinkTime;

    void Update()
    {
        if (!stop)
        {
            monster_Move();
            Cancer_AttackArea_SizrUp();
            Cancer_Attack();
        }
    }

    void Cancer_AttackArea_SizrUp()
    {
        float scale = cancerAttackArea.transform.localScale.x + Time.deltaTime * sizeUpSpeed;
        cancerAttackArea.transform.localScale = new Vector2(scale, scale);
    }

    void Cancer_Attack()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= blinkTime)
        {
            cancerAttackArea_cancerCollider.enabled = false;
            cancerAttackArea_cancerCollider.enabled = true;
            elapsedTime = 0;
        }
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
