using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PgHeal : Item, IItem
{
    public void Use()
    {
        GameManager.instance_.healPain(10f);
        Destroy(gameObject);
    }
}
    
