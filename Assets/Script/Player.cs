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
        ////좌우입력 받기
        //float v = Input.GetAxis("Vertical");
        ////상하 이동 받기
        //speedNomal = (new Vector2(h, v));
        //// 벡터에 입력
        //if (speedNomal.magnitude > 1)
        //    speedNomal = speedNomal.normalized;
        ////백터 노멀라이즈(정규화)
        //transform.Translate(speedNomal * (speed));
        ////벡터에 곱해줌
    }

    
}
