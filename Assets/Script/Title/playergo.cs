using System.Collections;
using UnityEngine;

public class playergo : MonoBehaviour
{
    public static bool go;

    private void Start()
    {
        go = false;
    }

    private void Update()
    {
        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, 10), 0.01f);
        }
    }
}
