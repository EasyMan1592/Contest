using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHeal : MonoBehaviour, IItem
{
    public void Use()
    {
        GameManager.instance_.playerHeal(15);
        Destroy(gameObject);
    }
}
