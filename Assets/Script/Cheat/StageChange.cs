using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour
{

    public void goStage1()
    {
        StartCutScene.instance.GoToStage1_();
        Cheat.instance.f2Esc();
    }

    public void goStage2()
    {
        BossManager.instance_.GotoStage2_();
        Cheat.instance.f2Esc();
    }
}
