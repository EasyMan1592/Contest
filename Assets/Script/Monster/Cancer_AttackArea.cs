using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cancer_AttackArea : MonoBehaviour
{
    [SerializeField] int cancerDamage;
    [SerializeField] int cancerPainDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance_.playerDamage(cancerDamage);
        }
    }
}