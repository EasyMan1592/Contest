using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Renderer back1;
    public Renderer back2;

    private float offset;

    public float speed1;
    public float speed2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime;

        back1.material.mainTextureOffset = new Vector2(0, offset) * speed1;
        back2.material.mainTextureOffset = new Vector2(0, offset) * speed2;

    }
}
