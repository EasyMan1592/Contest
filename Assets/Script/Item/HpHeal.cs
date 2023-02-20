using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHeal : Item, IItem
{
    public void Use()
    {
        GameManager.instance_.playerHeal(15f);
        GameManager.instance_.itemUse();
        GameManager.instance_.scoreUp(100, transform);
        Destroy(gameObject);
    }
}
