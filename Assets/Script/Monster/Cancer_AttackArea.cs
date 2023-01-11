using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cancer_AttackArea : MonoBehaviour
{
    [SerializeField] float elapsedTime;
    [SerializeField] float cheakTime;
    [SerializeField] int cancerDamage;
    [SerializeField] int cancerPainDamage;
    [SerializeField] bool inPlayer;

    private void Start()
    {
        inPlayer = false;
    }

    private void Update()
    {
        cancerBodyDamage();
    }

    void cancerBodyDamage()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= cheakTime)
        {
            if (inPlayer)
            {
                GameManager.instance_.playerDamage(cancerDamage);
            }
            elapsedTime = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inPlayer = true;
        }
        else
        {
            inPlayer = false;
        }
    }
}
