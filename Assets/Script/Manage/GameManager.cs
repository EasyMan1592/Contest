using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System.Linq.Expressions;
using System;
using JetBrains.Annotations;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public GameObject player_Obj;
    public Player player;
    public SpriteRenderer player_SPR;

    public GameObject getScoreText;

    public bool pause;

    public bool cutSceneRunning;
    public bool stage1clear;
    public bool stage2clear;

    public GameObject GameoverDisplay;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
        }
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

    public int score = 0;
    public bool isGameover = false;
    public int stage;
    [SerializeField] float invinceTime = 2f;
    public float playerHp = 100;
    public float painGauge = 0;
    [SerializeField] GameObject shieldObj;
    public bool canGetDamage = true;

    public int FireGrade;
    public Slider hpBar;
    public Text hpText;
    public Slider painBar;
    public Text painText;
    public Text scoreText;

    public int itemUsePrequancy;

    public float time;

    public int Next;
    public int BestScore;

    public bool inTop5;

    public void itemUse()
    {
        if (!isGameover)
        {
            itemUsePrequancy++;
        }
    }

    private void Start()
    {
        updateUI();
        canGetDamage = true;
        pause = false;
        cutSceneRunning = false;
        inTop5 = false;
    }

    void Update()
    {
        if (player == null)
        {
            Time.timeScale = 0;
        }

        timer();

        Gameover();
    }

    void timer()
    {
        if (!isGameover)
        {
            time += Time.deltaTime;
        }
    }

    ///================///

    public void updateUI()
    {

        if (!isGameover)
        {
            scoreText.text = score.ToString("D5");
            hpBar.value = playerHp;
            painBar.value = painGauge;
            hpText.text = playerHp + "%";
            painText.text = painGauge + "%";
            if (BossManager.instance_.bossFighting)
            {
                BossManager.instance_.bossUIUpdate();
            }
        }
    }

    public void scoreUp(int newscore, Transform hitPoint)
    {
        if (!isGameover)
        {
            score += newscore;
            //GameObject text = Instantiate(getScoreText, hitPoint.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            updateUI();
        }
    }

    public bool playerDamage(float newdamage)
    {
        if (!isGameover)
        {
            if (canGetDamage)
            {
                playerHp -= newdamage;
                contactTheMonster(invinceTime);
                if (playerHp <= 0)
                {
                    playerHp = 0;
                }
                updateUI();
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public void playerHeal(float newhealamount)
    {
        if (!isGameover)
        {
            playerHp += newhealamount;
            if (playerHp >= 100)
            {
                playerHp = 100;
            }

            updateUI();
        }
    }

    //치트
    public void hpSet(float newhp)
    {
        playerHp = newhp;
        updateUI();
    }

    public void getPain(float newpain)
    {
        if (!isGameover)
        {
            painGauge += newpain;
            if (painGauge >= 100)
            {
                painGauge = 100;
            }
            updateUI();
        }
    }

    public void healPain(float newhealamount)
    {
        if (!isGameover)
        {
            painGauge -= newhealamount;

            if (painGauge <= 0)
            {
                painGauge = 0;
            }
            updateUI();
        }
    }

    // 치트
    public void pgSet(float newpg)
    {
        painGauge = newpg;
        updateUI();
    }

    public void fireUpgrade()
    {
        if (FireGrade >= 5)
        {
            FireGrade = 5;
        }
        else
        {
            FireGrade++;
        }
    }

    // 치트
    public void fireGradeSet(int newfiregrade)
    {
        FireGrade = newfiregrade;
    }

    public void onShield(float newshieldtime)
    {
        if (!isGameover)
        {
            IEnumerator shield_ = shield(newshieldtime);
            IEnumerator shieldBlink_ = shieldBlink(newshieldtime);
            StopCoroutine(shield_);
            StartCoroutine(shield_);
            StopCoroutine(shieldBlink_);
            StartCoroutine(shieldBlink_);
        }
    }

    public void contactTheMonster(float newinvincetime)
    {
        if (!isGameover)
        {
            IEnumerator invince_ = invince(newinvincetime);
            IEnumerator playerBlink = objectBlink(player_SPR, newinvincetime);
            StopCoroutine(invince_);
            StartCoroutine(invince_);
            StopCoroutine(playerBlink);
            StartCoroutine(playerBlink);
        }
    }

    IEnumerator invince(float newinvincetime_)
    {
        canGetDamage = false;
        yield return new WaitForSecondsRealtime(newinvincetime_);
        canGetDamage = true;
    }

    IEnumerator shield(float newshieldtime_)
    {
        shieldObj.SetActive(true);
        canGetDamage = false;
        yield return new WaitForSecondsRealtime(newshieldtime_);
        shieldObj.SetActive(false);
        if(!Cheat.instance.isF4On) canGetDamage = true;
    }

    IEnumerator shieldBlink(float newshieldtime__)
    {
        float shieldOnTime = newshieldtime__ - 0.8f;
        yield return new WaitForSecondsRealtime(shieldOnTime);
        StartCoroutine(objectBlink(shieldObj.GetComponent<Renderer>(), 0.8f));
    }

    public void blink(Renderer newgameobject, float newblinktime)
    {
        StartCoroutine(objectBlink(newgameobject, newblinktime));
    }

    IEnumerator objectBlink(Renderer renderer, float newblinktime)
    {
        for (int i = 1; i <= (newblinktime * 10); i++)
        {
            if (i % 2 != 0)
            {
                renderer.enabled = false;
                yield return new WaitForSecondsRealtime(0.1f);
            }
            else
            {
                renderer.enabled = true;
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
        renderer.enabled = true;
    }

    void Gameover()
    {
        if(playerHp <= 0 || painGauge >= 100)
        {
            Cheat.instance.canDisplayOn = false;
            isGameover = true;
            pause = true;
            GameoverDisplay.SetActive(true);
            
            GameoverManager.instance.gameoverDisplaySet_();
        }
    }

}
