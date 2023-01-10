using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D playerRigid;

    Vector2 speedNomal;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveControl();
    }

    void moveControl()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;
        playerRigid.velocity = new Vector2(x, y);

        //float h = Input.GetAxis("Horizontal");
        ////�¿��Է� �ޱ�
        //float v = Input.GetAxis("Vertical");
        ////���� �̵� �ޱ�
        //speedNomal = (new Vector2(h, v));
        //// ���Ϳ� �Է�
        //if (speedNomal.magnitude > 1)
        //    speedNomal = speedNomal.normalized;
        ////���� ��ֶ�����(����ȭ)
        //transform.Translate(speedNomal * (speed));
        ////���Ϳ� ������
    }

    
}
