using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public Player player;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public static GameManager instance_
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    [SerializeField] int score = 0;
    [SerializeField] int playerHp = 100;
    [SerializeField] int painGauge = 0;
    [SerializeField] bool isGmaeover = false;

    public Slider hpBar;
    public Slider painBar;
    public Text scoreText;

    void Update()
    {
        if (player == null)//플레이어가 없다면
        {
            //시간 정지
            Time.timeScale = 0;
        }
    }

    public void updateUI()
    {
        scoreText.text = score.ToString("D5");
        hpBar.value = hpBar.maxValue / playerHp;
        painBar.value = hpBar.maxValue / painGauge;
    }

    public void scoreUp(int newscore)
    {
        score += newscore;
        updateUI();
    }   

    public void playerDamage(int newdamage)
    {
        playerHp -= newdamage;
        updateUI();
    }
    
    public void getPain(int newpain)
    {
        painGauge -= newpain;
        updateUI();
    }

    public void Gameover()
    {
        isGmaeover = true;
    }
}
