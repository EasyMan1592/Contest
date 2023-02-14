using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public GameObject cheatDisplay;
    public GameObject f3Display;
    bool isDisplayOn;

    private void Start()
    {
        isDisplayOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        cheat();
    }

    void cheat()
    {
        if (!isDisplayOn)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                cheatDisplay.SetActive(true);
                Time.timeScale = 0;
                isDisplayOn = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                cheatDisplay.SetActive(false);
                Time.timeScale = 1;
                isDisplayOn = false;
            }
        }






    }
}
