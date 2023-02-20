using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : Item, IItem
{
    public void Use()
    {
        GameManager.instance_.DamageUp_(5f);
        GameManager.instance_.itemUse();
        GameManager.instance_.scoreUp(100, transform);
        Destroy(gameObject);
    }
}