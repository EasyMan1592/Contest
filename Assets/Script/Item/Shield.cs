using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item, IItem
{
    public void Use()
    {
        GameManager.instance_.onShield(3f);
        Destroy(gameObject);
    }
}
