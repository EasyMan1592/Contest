using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class germs_Bullet : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;

    [SerializeField] float speed;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);

        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;

        dir = playerTransform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

}
