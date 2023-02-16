using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public GameObject player;
    public Text smallStageText;

    public GameObject bigStageText_Obj;
    public Text bigStageText;

    public GameObject black_Obj;
    public Image black;
    public GameObject[] TitleObjects;


    private void Start()
    {
        instance = this;
    }

    public void GameStart()
    {
        StartCoroutine(GameStart_());
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void goToStage1()
    {
        player.transform.position = new Vector2(0, -6);
        smallStageText.text = "Stage 1";
        bigStageText_Obj.SetActive(true);
        bigStageText.text = "Stage 1";
        StartCoroutine(BigStageTextFadeOut());
    }

    public void Stage1in_()
    {
        StartCoroutine(Stage1in());
    }


    public void goToStage2()
    {
        player.transform.position = new Vector2(0, -6);
        smallStageText.text = "Stage 2";
        bigStageText_Obj.SetActive(true);
        bigStageText.text = "Stage 2";
        StartCoroutine(BigStageTextFadeOut());
    }

    public void BlackOut_()
    {
        StartCoroutine(BlackOut());
    }

    IEnumerator GameStart_()
    {
        black_Obj.SetActive(true);
        playergo.go = true;
        float fadeCount = 0;
        while (fadeCount <= 1f)
        {
            fadeCount += 0.001f;
            yield return null;
            black.color = new Color(black.color.r, black.color.g, black.color.b, fadeCount);
        }
        SceneManager.LoadScene("Stage1");
    }

    IEnumerator Stage1in()
    {
        float fadeCount = 1;
        while (fadeCount >= 0f)
        {
            fadeCount -= 0.001f;
            yield return null;
            black.color = new Color(black.color.r, black.color.g, black.color.b, fadeCount);
        }
    }

    IEnumerator BlackOut()
    {
        float fadeCount = 0;
        while (fadeCount <= 1f)
        {
            fadeCount += 0.001f;
            yield return null;
            black.color = new Color(black.color.r, black.color.g, black.color.b, fadeCount);
        }
        fadeCount = 1;
        while (fadeCount >= 0f)
        {
            fadeCount -= 0.001f;
            yield return null;
            black.color = new Color(black.color.r, black.color.g, black.color.b, fadeCount);
        }
    }



    IEnumerator BigStageTextFadeOut()
    {
        float fadeCount = 1;
        while (fadeCount >= 0f)
        {
            fadeCount -= 0.001f;
            yield return null;
            bigStageText.color = new Color(bigStageText.color.r, bigStageText.color.g, bigStageText.color.b, fadeCount);
        }
        bigStageText_Obj.SetActive(false);
    }



}
