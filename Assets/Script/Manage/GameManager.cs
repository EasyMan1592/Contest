using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public GameObject player_Obj;
    public Player player;
    public SpriteRenderer player_SPR;

    public GameObject bulletPrefab;
    public Sprite[] BulletSprite;

    public bool pause;

    public bool cutSceneRunning;
    public bool stage1clear;
    public bool stage2clear;

    public GameObject GameoverDisplay;
    public Text GameoverText;

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
    public GameObject shieldObj;
    public GameObject boostObj;
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
            if (!stage1clear || !stage2clear)
            {
                itemUsePrequancy++;
            }
        }
    }
    

    private void Start()
    {

        time = 0;
        canGetDamage = true;
        pause = false;
        cutSceneRunning = false;
        inTop5 = false;
        isGameover = false;
        Next = 0;
        playerHp = 100;
        painGauge = 10;

        updateUI();
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
            if (!stage1clear || !stage2clear)
            {
                time += Time.deltaTime;
            }
        }
    }

    ///================///

    public void updateUI()
    {
        if (!isGameover)
        {
            if (!stage1clear || !stage2clear)
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
    }

    public void scoreUp(int newscore, Transform hitPoint)
    {
        if (!isGameover)
        {
            if (!stage1clear || !stage2clear)
            {
                score += newscore;
                //GameObject text = Instantiate(getScoreText, hitPoint.position, Quaternion.identity, GameObject.Find("Canvas").transform);
                updateUI();
                scoreTextBlink_();
            }
        }
    }

    public bool playerDamage(float newdamage)
    {
        if (!isGameover)
        {
            if (!stage1clear || !stage2clear)
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
        return false;
    }

    public void playerHeal(float newhealamount)
    {
        if (!isGameover)
        {
            if (!stage1clear || !stage2clear)
            {
                playerHp += newhealamount;
                if (playerHp >= 100)
                {
                    playerHp = 100;
                }

                updateUI();
            }
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
            if (!stage1clear || !stage2clear)
            {
                painGauge += newpain;
                if (painGauge >= 100)
                {
                    painGauge = 100;
                }
                updateUI();
            }
        }
    }

    public void healPain(float newhealamount)
    {
        if (!isGameover)
        {
            if (!stage1clear || !stage2clear)
            {
                painGauge -= newhealamount;

                if (painGauge <= 0)
                {
                    painGauge = 0;
                }
                updateUI();
            }
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
        if (!isGameover)
        {
            if (!stage1clear || !stage2clear)
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
            if (!stage1clear || !stage2clear)
            {
                IEnumerator shield_ = shield(newshieldtime);
                IEnumerator shieldBlink_ = shieldBlink(newshieldtime);
                StopCoroutine(shield_);
                StartCoroutine(shield(newshieldtime));
                StopCoroutine(shieldBlink_);
                StartCoroutine(shieldBlink(newshieldtime));
            }
        }
    }

    public void contactTheMonster(float newinvincetime)
    {
        if (!isGameover)
        {
            if (!stage1clear || !stage2clear)
            {
                IEnumerator invince_ = invince(newinvincetime);
                IEnumerator playerBlink = objectBlink(player_SPR, newinvincetime);
                StopCoroutine(invince_);
                StartCoroutine(invince(newinvincetime));
                StopCoroutine(playerBlink);
                StartCoroutine(objectBlink(player_SPR, newinvincetime));
            }
        }
    }

    public void DamageUp_(float newdamageuptime_)
    {
        if (!isGameover)
        {
            if (!stage1clear || !stage2clear)
            {
                IEnumerator DamageUp__ = DamageUp(newdamageuptime_);
                StopCoroutine(DamageUp__);
                StartCoroutine(DamageUp(newdamageuptime_));
            }
        }
    }

    IEnumerator DamageUp(float newdamageuptime_)
    {
        bulletPrefab.GetComponent<Bullet>().bulletDamage = 2;
        bulletPrefab.GetComponent<SpriteRenderer>().sprite = BulletSprite[1];
        yield return new WaitForSecondsRealtime(newdamageuptime_);
        bulletPrefab.GetComponent<Bullet>().bulletDamage = 1;
        bulletPrefab.GetComponent<SpriteRenderer>().sprite = BulletSprite[0];
    }


    public void Boost_(float newboosttime_)
    {
        if (!isGameover)
        {
            if (!stage1clear || !stage2clear)
            {
                IEnumerator Boost__ = Boost(newboosttime_);
                IEnumerator BoostBlink__ = boostBlink(newboosttime_);
                StopCoroutine(Boost__);
                StartCoroutine(Boost(newboosttime_));
                StopCoroutine(BoostBlink__);
                StartCoroutine(boostBlink(newboosttime_));
            }
        }
    }

    IEnumerator Boost(float newboosttime_)
    {
        Fire.instance.fireTime = 0.06f;
        boostObj.SetActive(true);
        yield return new WaitForSecondsRealtime(newboosttime_);
        Fire.instance.fireTime = 0.1f;
        boostObj.SetActive(false);
    }

    void scoreTextBlink_()
    {
        StartCoroutine(scoreTextBlink());
    }

    IEnumerator scoreTextBlink()
    {
        scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 255);
        yield return new WaitForSecondsRealtime(0.1f);
        scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 255);
        yield return new WaitForSecondsRealtime(0.1f);
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

    IEnumerator boostBlink(float newshieldtime__)
    {
        float shieldOnTime = newshieldtime__ - 0.8f;
        yield return new WaitForSecondsRealtime(shieldOnTime);
        StartCoroutine(objectBlink(boostObj.GetComponent<Renderer>(), 0.8f));
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
