using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHeal : Item, IItem
{
    public void Use()
    {
        GameManager.instance_.playerHeal(15f);
        Destroy(gameObject);
    }
}
