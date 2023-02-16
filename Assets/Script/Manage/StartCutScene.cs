using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutScene : MonoBehaviour
{
    public static StartCutScene instance;

    void Start()
    {
        instance = this;
        GoToStage1_();
    }

    public void GoToStage1_()
    {
        StartCoroutine(GoToStage1());
    }

    IEnumerator GoToStage1()
    {
        GameManager.instance_.stage1clear = true;
        StageManager.instance.black_Obj.SetActive(true);
        StageManager.instance.black.color = new Color(0, 0, 0, 255);
        StageManager.instance.Stage1in_();
        StageManager.instance.goToStage1();
        GameManager.instance_.stage = 0;
        yield return new WaitForSecondsRealtime(0.7f);
        StageManager.instance.black_Obj.SetActive(false);
        GameManager.instance_.stage1clear = false;
        MonsterSpawner.time = 0;
        Cheat.coroutinePlay();
    }
}
