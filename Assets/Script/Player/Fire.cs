using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField]
    private float fireTime;

    private void Awake()
    {
        Cheat.OnAllCouroutinePlay += fire_Play;
    }

    void fire_Play()
    {
        StartCoroutine(fire());
    }

    IEnumerator fire()
    {
        if (!GameManager.instance_.stage1clear)
        {
            if (!GameManager.instance_.pause)
            {
                switch (GameManager.instance_.FireGrade)
                {
                    case 1:
                        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.2f, transform.position.y), Quaternion.identity);
                        Instantiate(bulletPrefab, new Vector2(transform.position.x + 0.2f, transform.position.y), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.2f, transform.position.y), Quaternion.Euler(0f, 0f, +7));
                        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                        Instantiate(bulletPrefab, new Vector2(transform.position.x + 0.2f, transform.position.y), Quaternion.Euler(0f, 0f, -7));
                        break;
                    case 4:
                        Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.2f, transform.position.y), Quaternion.Euler(0f, 0f, +7));
                        Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.13f, transform.position.y), Quaternion.Euler(0f, 0f, +1));
                        Instantiate(bulletPrefab, new Vector2(transform.position.x + 0.13f, transform.position.y), Quaternion.Euler(0f, 0f, -1));
                        Instantiate(bulletPrefab, new Vector2(transform.position.x + 0.2f, transform.position.y), Quaternion.Euler(0f, 0f, -7));
                        break;
                    case 5:
                        Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.2f, transform.position.y), Quaternion.Euler(0f, 0f, +7));
                        Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.16f, transform.position.y), Quaternion.Euler(0f, 0f, +2));
                        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                        Instantiate(bulletPrefab, new Vector2(transform.position.x + 0.16f, transform.position.y), Quaternion.Euler(0f, 0f, -2));
                        Instantiate(bulletPrefab, new Vector2(transform.position.x + 0.2f, transform.position.y), Quaternion.Euler(0f, 0f, -7));
                        break;
                }
                yield return new WaitForSecondsRealtime(fireTime);
                StartCoroutine(fire());
            }
        }
    }
}
