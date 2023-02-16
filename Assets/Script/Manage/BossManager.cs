using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class BossManager : MonoBehaviour
{
    private static BossManager instance = null;
    public GameObject player;
    

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public static BossManager instance_
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

    public Transform bossTransform;
    public GameObject[] bosses;
    public List<GameObject> bosses_ = new List<GameObject>();
    public GameObject bossHpBar_Obj;
    public Slider bossHpBar_Sli;
    public float[] bossSpawnScores;
    public bool bossFighting;
    [SerializeField] Boss[] boss;
    [SerializeField] float[] maxhp;

    private void Start()
    {
        for (int i = 0; i < bosses.Length; i++)
        {
            bosses_.Add(Instantiate(bosses[i], new Vector2(0f, 7f), Quaternion.identity));
            bosses_[i].SetActive(false);

            boss[i] = bosses_[i].GetComponent<Boss>();
            maxhp[i] = boss[i].monster_HP;
        }
    }

    void Update()
    {
        if (GameManager.instance_.score >= bossSpawnScores[GameManager.instance_.stage])
        {
            instance_.bossUIUpdate();
            bossFightStart();
        }
    }

    void bossFightStart()
    {
        bossFighting = true;
        spawnBoss(bosses_[GameManager.instance_.stage]);
    }

    int j;

    void spawnBoss(GameObject newboss)
    {
        newboss.transform.position = Vector3.MoveTowards(newboss.transform.position, bossTransform.position, 0.01f);
        if(j == 0) StartCoroutine(bossActive(newboss));
    }

    IEnumerator bossActive(GameObject newboss)
    {
        bossHpBar_Obj.SetActive(true);
        newboss.SetActive(true);
        j++;
        yield return null;
    }

    public void bossUIUpdate()
    {
        bossHpBar_Sli.value = boss[GameManager.instance_.stage].monster_HP / maxhp[GameManager.instance_.stage];
    }

    public void bossClear()
    {
        
        if(GameManager.instance_.stage == 0 )
        {
            StartCoroutine(clearCutScene_Stage1());
        }
        else if (GameManager.instance_.stage == 1)
        {
            
        }
    }

    public void GotoStage2_()
    {
        StartCoroutine(GoToStage2());
    }

    IEnumerator clearCutScene_Stage1()
    {
        yield return new WaitForSecondsRealtime(6f);
        GameManager.instance_.stage1clear = true;
        yield return new WaitForSecondsRealtime(1f);
        StageManager.instance.black_Obj.SetActive(true);
        StageManager.instance.BlackOut_();
        yield return new WaitForSecondsRealtime(3f);
        StageManager.instance.goToStage2();
        yield return new WaitForSecondsRealtime(0.7f);
        StageManager.instance.black_Obj.SetActive(false);
        GameManager.instance_.stage = 1;
        GameManager.instance_.stage1clear = false;
        bossFighting = false;
        MonsterSpawner.time = 1000;
        Cheat.coroutinePlay();
    }

    IEnumerator GoToStage2()
    {
        GameManager.instance_.stage1clear = true;
        StageManager.instance.black_Obj.SetActive(true);
        StageManager.instance.Stage1in_();
        StageManager.instance.goToStage2();
        yield return new WaitForSecondsRealtime(0.7f);
        StageManager.instance.black_Obj.SetActive(false);
        GameManager.instance_.stage = 1;
        GameManager.instance_.stage1clear = false;
        bossFighting = false;
        MonsterSpawner.time = 1000;
        Cheat.coroutinePlay();
    }





}
