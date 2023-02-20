using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScoreManager : MonoBehaviour
{
    public static BonusScoreManager instance;
    

    private void Awake()
    {
        instance = this;
    }

    public GameObject BounsDisplay;

    public Text HP_Score;
    public Text PG_Score;
    public Text Total_Score;

    public void BounsScoreCal_()
    {
        StartCoroutine(BounsScoreCal());
    }

    IEnumerator BounsScoreCal()
    {
        BounsDisplay.SetActive(true);
        GameManager.instance_.canGetDamage = false;
        HP_Score.text = ((int)GameManager.instance_.playerHp) + " X 50";
        PG_Score.text = (100 - (int)GameManager.instance_.painGauge) + " X 50";
        int bonusScore = (int)((GameManager.instance_.playerHp * 50) + ((100 - GameManager.instance_.painGauge) * 50));
        Total_Score.text = bonusScore.ToString("D5");
        yield return new WaitForSecondsRealtime(5f);
        GameManager.instance_.canGetDamage = true;
        BounsDisplay.SetActive(false);
        GameManager.instance_.scoreUp(bonusScore, transform);
    }
}
