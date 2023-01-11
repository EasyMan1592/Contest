using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System.Linq.Expressions;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public Player player;
    public SpriteRenderer player_SPR;

    public enum FireGrade { Fir, Sec, Thi, Fou, Fif};

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
    [SerializeField] float playerHp = 100;
    [SerializeField] float painGauge = 0;
    [SerializeField] float maxHp = 100;
    [SerializeField] float maxPain = 100;
    [SerializeField] bool canGetDamage = true;
    [SerializeField] bool isGmaeover = false;

    public Slider hpBar;
    public Slider painBar;
    public Text scoreText;

    private void Start()
    {
        updateUI();
        canGetDamage = true;
    }

    void Update()
    {
        if (player == null)
        {
            Time.timeScale = 0;
        }
    }

    public void updateUI()
    {
        scoreText.text = score.ToString("D5");
        hpBar.value = playerHp / maxHp;
        painBar.value = painGauge / maxPain;
    }

    public void scoreUp(int newscore, Transform hitPoint)
    {
        score += newscore;
        updateUI();
    }

    public bool playerDamage(float newdamage)
    {
        if(canGetDamage == true)
        {
            playerHp -= newdamage;
            StartCoroutine(invince());
            StartCoroutine(invince_Graphic());
            updateUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator invince()
    {
        canGetDamage = false;
        yield return new WaitForSecondsRealtime(1.5f);
        canGetDamage = true;
    }

    IEnumerator invince_Graphic()
    {
        for(int i = 1; i < 15; i++)
        {
            if(i % 2 != 0)
            {
                player_SPR.enabled = false;
                yield return new WaitForSecondsRealtime(0.1f);
            }
            else
            {
                player_SPR.enabled = true;
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
    }
    
    public void getPain(float newpain)
    {
        painGauge += newpain;
        updateUI();
    }

    public void Gameover()
    {
        isGmaeover = true;

        
    }
}
