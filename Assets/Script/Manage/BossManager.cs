using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class BossManager : MonoBehaviour
{
    private static BossManager instance = null;

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
    public float[] bossSpawnScores;
    public bool bossFighting;
    public GameObject bossHpBar;

    void Update()
    {
        if (GameManager.instance_.score >= bossSpawnScores[0])
        {
            bossFightStart();
        }
    }

    void bossFightStart()
    {
        bossFighting = true;
        spawnBoss(bosses[0]);
    }

    void spawnBoss(GameObject newboss)
    {
        newboss.SetActive(true);
        newboss.transform.position = Vector3.MoveTowards(bosses[0].transform.position, bossTransform.position, 0.01f);
        bossHpBar.SetActive(true);
    }

    public void bossUIUpdate()
    {
        Boss boss = bosses[0].GetComponent<Boss>();
        Slider HpBar = bossHpBar.GetComponent<Slider>();

        float maxhp = boss.monster_HP;
        HpBar.value = boss.monster_HP / maxhp;
    }
}
