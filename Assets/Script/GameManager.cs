using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System.Linq.Expressions;
using System;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public Player player;
    public SpriteRenderer player_SPR;

    public GameObject getScoreText;

    // ������ ���� �ۺ��� ����
    
    

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

    [SerializeField] float invinceTime = 2f;
    [SerializeField] int score = 0;
    [SerializeField] float playerHp = 100;
    [SerializeField] float painGauge = 0;
    [SerializeField] float maxHp = 100;
    [SerializeField] float maxPain = 100;
    [SerializeField] bool canGetDamage = true;
    [SerializeField] bool isGmaeover = false;
    [SerializeField] int FireGrade;
    [SerializeField] GameObject shieldObj;

    public Slider hpBar;
    public Slider painBar;
    public Text scoreText;

    private void Start()
    {
        updateUI();
        canGetDamage = true;

        Mathf.Clamp(FireGrade, 1, 5);
    }

    void Update()
    {
        if (player == null)
        {
            Time.timeScale = 0;
        }
    }

    ///================///

    public void updateUI()
    {
        scoreText.text = score.ToString("D5");
        hpBar.value = playerHp / maxHp;
        painBar.value = painGauge / maxPain;
    }

    public void scoreUp(int newscore, Transform hitPoint)
    {
        score += newscore;
        //GameObject text = Instantiate(getScoreText, hitPoint.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        updateUI();
    }

    public bool playerDamage(float newdamage)
    {
        if (canGetDamage == true)
        {
            playerHp -= newdamage;
            contactTheMonster(invinceTime);
            updateUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void playerHeal(float newhealamount)
    {
        playerHp += newhealamount;
        updateUI();
    }

    public void getPain(float newpain)
    {
        painGauge += newpain;
        updateUI();
    }

    public void healPain(float newhealamount)
    {
        painGauge += newhealamount;
        updateUI();
    }

    public void fireUpgrade()
    {
        FireGrade++;
    }

    public void onShield(float newshieldtime)
    {
        IEnumerator shield_ = shield(newshieldtime);
        IEnumerator shieldBlink_ = shieldBlink(newshieldtime);
        StopCoroutine(shield_);
        StartCoroutine(shield_);
        StopCoroutine(shieldBlink_);
        StartCoroutine(shieldBlink_);
    }

    public void contactTheMonster(float newinvincetime)
    {
        IEnumerator invince_ = invince(newinvincetime);
        IEnumerator playerBlink = objectBlink(player_SPR, newinvincetime);
        StopCoroutine(invince_);
        StartCoroutine(invince_);
        StopCoroutine(playerBlink);
        StartCoroutine(playerBlink);
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
        canGetDamage = true;
    }

    IEnumerator shieldBlink(float newshieldtime__)
    {
        float shieldOnTime = newshieldtime__ - 0.8f;
        yield return new WaitForSecondsRealtime(shieldOnTime);
        StartCoroutine(objectBlink(shieldObj.GetComponent<Renderer>(), 0.8f));
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

    

    public void Gameover()
    {
        isGmaeover = true;
    }
}