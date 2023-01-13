using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : Blood
{
    public GameObject[] ItemPrefabs; // 0 1 2 3
     
    protected override void die()
    {
        base.die();
        spawnItem();
    }

    void spawnItem()
    {
        int SP = Random.Range(0, ItemPrefabs.Length);
        Instantiate(ItemPrefabs[SP], transform.position, Quaternion.identity);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            die();
        }
    }

}
