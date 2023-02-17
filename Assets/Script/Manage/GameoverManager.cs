using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq.Expressions;

public class GameoverManager : MonoBehaviour
{
    public static GameoverManager instance;

    private void Start()
    {
        instance = this;
    }

    public Text playScoreText;
    public Text itemScoreText;
    public Text HPScoreText;
    public Text PGScoreText;
    public Text TotalScoreText;
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


                if (Input.anyKeyDown)
                {
                    GameManager.instance_.Next = 1;
                }
               
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
                //Scenes[2].SetActive(true);
            }
        }
    }

    public void gameoverDisplaySet_()
    {
        StartCoroutine(gameoverDisplaySet());
    }

    IEnumerator gameoverDisplaySet()
    {
        playScoreText.text = GameManager.instance_.score.ToString("");
        itemScoreText.text = GameManager.instance_.itemUsePrequancy + " X 100";
        HPScoreText.text = GameManager.instance_.playerHp + " X 10";
        PGScoreText.text = 100 - GameManager.instance_.painGauge + " X 10";
        TotalScoreText.text = (GameManager.instance_.score + GameManager.instance_.itemUsePrequancy * 100 + GameManager.instance_.playerHp * 10 + ((100 - GameManager.instance_.painGauge) * 10)).ToString("");
        GameManager.instance_.BestScore = (int)(GameManager.instance_.score + GameManager.instance_.itemUsePrequancy * 100 + GameManager.instance_.playerHp * 10 + ((100 - GameManager.instance_.painGauge) * 10));
        yield return new WaitForSecondsRealtime(3f);
        NextText.SetActive(true);
    }
}