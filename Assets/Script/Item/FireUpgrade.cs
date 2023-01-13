using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUpgrade : Item, IItem
{
    public void Use()
    {
        GameManager.instance_.fireUpgrade();
        Destroy(gameObject);
    }
}
