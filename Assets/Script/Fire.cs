using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField]
    private float fireTime;
    IEnumerator fireCoroutine;

    void Start()
    {
        fireCoroutine = fire();
        StartCoroutine(fireCoroutine);
    }

    IEnumerator fire()
    {
        fireCoroutine = fire();
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(fireTime);
        StartCoroutine(fireCoroutine);
    }

}
