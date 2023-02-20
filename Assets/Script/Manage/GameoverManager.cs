using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverManager : MonoBehaviour
{
    public static GameoverManager instance;

    private void Start()
    {
        instance = this;
    }

    public Text ScoreText;
    public GameObject NextText;

    public GameObject[] Scenes;

    public void Update()
    {
        if (GameManager.instance_.isGameover)
        {
            if (GameManager.instance_.Next == 0)
            {
                Scenes[0].SetActive(true);
                gameoverDisplaySet_();

                Invoke("acc", 3f);
            }

            if (GameManager.instance_.Next == 1)
            {
                Scenes[0].SetActive(false);
                if (GameManager.instance_.inTop5)
                {
                    Scenes[1].SetActive(true);
                }
                else
                {
                    GameManager.instance_.Next = 2;
                }
            }

            if (GameManager.instance_.Next == 2)
            {
                Scenes[1].SetActive(false);
                Scenes[2].SetActive(true);
            }
        }
    }

    public void acc()
    {
        if (Input.anyKeyDown)
        {
            GameManager.instance_.Next = 1;
        }
    }

    public void gameoverDisplaySet_()
    {
        StartCoroutine(gameoverDisplaySet());
    }

    IEnumerator gameoverDisplaySet()
    {
        ScoreText.text = GameManager.instance_.score.ToString("D5");
        GameManager.instance_.BestScore = GameManager.instance_.score;
        yield return new WaitForSecondsRealtime(3f);
        NextText.SetActive(true);
    }
}