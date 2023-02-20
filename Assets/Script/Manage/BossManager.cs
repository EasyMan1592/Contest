using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float[] bossSpawnTime;
    public bool bossFighting;
    public Boss[] boss;
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
        bossUIUpdate();
        if ((int)GameManager.instance_.time == bossSpawnTime[GameManager.instance_.stage])
        {
            bossFightStart();
        }
    }

    void bossFightStart()
    {
        Boss.a = 0;
        bossFighting = true;
        spawnBoss(bosses_[GameManager.instance_.stage]);

    }

    public int j;

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
            StartCoroutine(clearCutScene_Stage2());
        }
    }

    public void GotoStage2_()
    {
        StartCoroutine(GoToStage2());
    }

    IEnumerator clearCutScene_Stage1()
    {
        yield return new WaitForSecondsRealtime(2f);
        BonusScoreManager.instance.BounsScoreCal_();
        yield return new WaitForSecondsRealtime(5.1f);
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
        GameManager.instance_.time = 1000;
        GameManager.instance_.updateUI();
        CoroutinePlay.instance.coroutinePlay();
    }
    
    IEnumerator clearCutScene_Stage2()
    {
        yield return new WaitForSecondsRealtime(2f);
        BonusScoreManager.instance.BounsScoreCal_();
        yield return new WaitForSecondsRealtime(5.1f);
        GameManager.instance_.stage2clear = true;
        GameManager.instance_.GameoverDisplay.SetActive(true);
        GameManager.instance_.GameoverText.text = "Clear";
        GameManager.instance_.isGameover = true;
        GameManager.instance_.time = 10000;
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
        GameManager.instance_.time = 1000;
        GameManager.instance_.playerHp = 100;
        GameManager.instance_.painGauge = 30;
        GameManager.instance_.updateUI();
        CoroutinePlay.instance.coroutinePlay();
    }





}
