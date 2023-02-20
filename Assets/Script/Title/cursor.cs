using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    public GameObject injector;

    public Transform[] injectorPos;   // 0:스타트   1:스코어   2:탈출
    public GameObject[] button_colls; // 0:스타트   1:스코어   2:탈출

    Vector2 MousePosition;
    Camera cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        //if (MousePosition.x < 0f) MousePosition.x = 0f;
        //if (MousePosition.x > 1f) MousePosition.x = 1f;
        //if (MousePosition.y < 0f) MousePosition.y = 0f;
        //if (MousePosition.y > 1f) MousePosition.y = 1f;

        transform.position = MousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == button_colls[0])
        {
            injector.transform.position = injectorPos[0].position;
        }

        if(collision.gameObject == button_colls[1])
        {
            injector.transform.position = injectorPos[1].position;
        }

        if (collision.gameObject == button_colls[2])
        {
            injector.transform.position = injectorPos[2].position;
        }
    }



}
