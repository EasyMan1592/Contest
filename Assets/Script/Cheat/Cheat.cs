using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour
{
    public static Cheat instance;
    
    public delegate void AllCouroutinePlay();
    public static event AllCouroutinePlay OnAllCouroutinePlay;

    public SpriteRenderer playerRenderer;

    public GameObject f1Display;

    public GameObject f2Display;

    public GameObject f3Display;
    public Slider f3Slider;
    public Text f3Text;

    public GameObject f7Display;
    public Slider f7Slider;
    public Text f7Text;

    public GameObject f8Display;
    public Slider f8Slider;
    public Text f8Text;

    public bool canDisplayOn;
    public bool isF1DisplayOn;
    public bool isF2DisplayOn;
    public bool isF3DisplayOn;
    public bool isF7DisplayOn;
    public bool isF8DisplayOn;

    public bool isF4On;

    public static void coroutinePlay()
    {
        OnAllCouroutinePlay();
    }


    private void Start()
    {
        instance = this;
        isF1DisplayOn = false;
        isF2DisplayOn = false;
        isF3DisplayOn = false;
        isF4On = false;
        isF7DisplayOn = false;
        isF8DisplayOn = false;
        

        f3_Start();
        f7_Start();
        f8_Start();
    }

    // Update is called once per frame
    void Update()
    {
        cheat();
        cheatText();
    }

    void cheatText()
    {
        f3Text.text = ((int)f3Slider.value).ToString("");
        f7Text.text = ((int)f7Slider.value) + "%";
        f8Text.text = ((int)f8Slider.value) + "%";
    }

    void cheat()
    {
        if(!isF1DisplayOn && !isF2DisplayOn && !isF3DisplayOn && !isF7DisplayOn && !isF8DisplayOn)
        {
            canDisplayOn = true;
        }
        else
        {
            canDisplayOn = false;
        }

        if (canDisplayOn)
        {
            // F1
            if (Input.GetKeyDown(KeyCode.F1))
            {
                f1Display.SetActive(true);
                GameManager.instance_.pause = true;
                Time.timeScale = 0;
                isF1DisplayOn = true;
            }

            // F2
            if (Input.GetKeyDown(KeyCode.F2))
            {
                f2Display.SetActive(true);
                GameManager.instance_.pause = true;
                Time.timeScale = 0;
                isF2DisplayOn = true;
            }

            // F3
            if (Input.GetKeyDown(KeyCode.F3))
            {
                f3_Start();
                f3Display.SetActive(true);
                GameManager.instance_.pause = true;
                Time.timeScale = 0;
                isF3DisplayOn = true;
            }

            // F4
            if (Input.GetKeyDown(KeyCode.F4))
            {
                GameManager.instance_.canGetDamage = false;
                playerRenderer.color = Color.yellow; 
                isF4On = true;
            }

            // F5
            if (Input.GetKeyDown(KeyCode.F5))
            {
                GameManager.instance_.canGetDamage = true;
                playerRenderer.color = Color.white;
                isF4On = false;
            }

            // F6
            if (Input.GetKeyDown(KeyCode.F6))
            {
                killAll();
            }

            // F7
            if (Input.GetKeyDown(KeyCode.F7))
            {
                f7_Start();
                f7Display.SetActive(true);
                GameManager.instance_.pause = true;
                Time.timeScale = 0;
                isF7DisplayOn = true;
            }

            // F8
            if (Input.GetKeyDown(KeyCode.F8))
            {
                f8_Start();
                f8Display.SetActive(true);
                GameManager.instance_.pause = true;
                Time.timeScale = 0;
                isF8DisplayOn = true;
            }
        }
        else
        {
            // ESC
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                f1Display.SetActive(false);
                f2Display.SetActive(false);
                f3Display.SetActive(false);
                f7Display.SetActive(false);
                f8Display.SetActive(false);
                GameManager.instance_.pause = false;
                OnAllCouroutinePlay();
                Time.timeScale = 1;
                isF1DisplayOn = false;
                isF2DisplayOn = false;
                isF3DisplayOn = false;
                isF7DisplayOn = false;
                isF8DisplayOn = false;
                f3_End();
                f7_End();
                f8_End();
            }
        }
    }

    public void f2Esc()
    {
        
        f1Display.SetActive(false);
        f2Display.SetActive(false);
        f3Display.SetActive(false);
        f7Display.SetActive(false);
        f8Display.SetActive(false);
        GameManager.instance_.pause = false;
        OnAllCouroutinePlay();
        Time.timeScale = 1;
        isF1DisplayOn = false;
        isF2DisplayOn = false;
        isF3DisplayOn = false;
        isF7DisplayOn = false;
        isF8DisplayOn = false;
        f3_End();
        f7_End();
        f8_End();
        killAll();
    }



    public void killAll()
    {
        if (BossManager.instance_.bossFighting)
        {
            GameObject b = FindObjectOfType<Boss>().gameObject;
            b.GetComponent<Boss>().Die__();
        }


        for (int i = 0; i < MonsterList.instance.monsters.Count; i++)
        {
            MonsterList.instance.monsters[i].GetComponent<Monster_Parents>().Die_();
        }
    }

    void f3_Start()
    {
        f3Slider.value = GameManager.instance_.FireGrade;
    }
    void f3_End()
    {
        GameManager.instance_.fireGradeSet((int)f3Slider.value);
    }

    void f7_Start()
    {
        f7Slider.value = GameManager.instance_.playerHp;
    }
    void f7_End()
    {
        GameManager.instance_.hpSet((int)f7Slider.value);
    }

    void f8_Start()
    {
        f8Slider.value = GameManager.instance_.painGauge;
    }
    void f8_End()
    {
        GameManager.instance_.pgSet((int)f8Slider.value);
    }
}
