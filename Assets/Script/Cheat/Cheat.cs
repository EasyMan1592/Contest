using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour
{
    public SpriteRenderer playerRenderer;

    public GameObject f1Display;

    public GameObject f3Display;
    public Slider f3slider;
    public Text f3Text;


    bool canDisplayOn;
    bool isF1DisplayOn;
    bool isF3DisplayOn;

    private void Start()
    {
        isF1DisplayOn = false;
        isF3DisplayOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        cheat();
    }

    void cheat()
    {
        if(!isF1DisplayOn && !isF3DisplayOn)
        {
            canDisplayOn = true;
        }
        else
        {
            canDisplayOn = false;
        }

        f3();


        if (canDisplayOn)
        {
            // F1
            if (Input.GetKeyDown(KeyCode.F1))
            {
                f1Display.SetActive(true);
                Time.timeScale = 0;
                isF1DisplayOn = true;
            }

            // F3
            if (Input.GetKeyDown(KeyCode.F3))
            {
                f3Display.SetActive(true);
                Time.timeScale = 0;
                isF3DisplayOn = true;
            }

            // F4
            if (Input.GetKeyDown(KeyCode.F4))
            {
                GameManager.instance_.canGetDamage = false;
                playerRenderer.color = Color.yellow;
            }

            // F5
            if (Input.GetKeyDown(KeyCode.F5))
            {
                GameManager.instance_.canGetDamage = true;
                playerRenderer.color = Color.white;
            }


            // F6
            if (Input.GetKeyDown(KeyCode.F5))
            {
                GameManager.instance_.canGetDamage = true;
                playerRenderer.color = Color.white;
            }

        }
        else
        {
            // ESC
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                f1Display.SetActive(false);
                f3Display.SetActive(false);
                Time.timeScale = 1;
                isF1DisplayOn = false;
                isF3DisplayOn = false;
            }
        }
    }

    List<GameObject> monsters = new List<GameObject>();
    List<GameObject> boss = new List<GameObject>();

    GameObject[] monsters_;

    void killAll()
    {
        
    }



    void f3()
    {
        GameManager.instance_.fireGradeSet((int)f3slider.value);
        f3Text.text = ((int)f3slider.value).ToString("");
    }
}
