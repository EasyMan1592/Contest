using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public GameObject[] monsterPrefabs; // 0: 박테리아, 1: 세균, 2: 바이러스, 3: 암

    [SerializeField] float spawnMinTime;
    [SerializeField] float spawnMaxTime;

    [SerializeField] GameObject spawnPos;
    [SerializeField] Transform spawnPos_;

    bool isCoroutineRunning;

    public static float time;

    private void Awake()
    {
        Cheat.OnAllCouroutinePlay += monsterSpawn_Play;
    }

    void Start()
    {
        isCoroutineRunning = false;
        spawnPos = GameObject.Find("MonsterSpawner");
        spawnPos_ = spawnPos.GetComponent<Transform>();
    }

    public void Update()
    {
        monsterListRemove();

        timer();
    }

    void timer()
    {
        time += Time.deltaTime;
    }

    void monsterListRemove()
    {
        for (int i = MonsterList.instance.monsters.Count - 1; i >= 0; i--)
        {
            if (MonsterList.instance.monsters[i] == null)
            {
                MonsterList.instance.monsters.Remove(MonsterList.instance.monsters[i]);
            }
        }
    }

    public void monsterSpawn_Play()
    {
        StartCoroutine(monsterSpawn());
    }
    
    IEnumerator monsterSpawn()
    {
        if (!BossManager.instance_.bossFighting)
        {
            if (!GameManager.instance_.pause)
            {
                if (!isCoroutineRunning)
                {
                    if (0 <= time && time < 15)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime + 1, spawnMaxTime + 1);
                        yield return new WaitForSecondsRealtime(waitTime);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[0], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (15 <= time && time < 45)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
                        yield return new WaitForSecondsRealtime(waitTime);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[0], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (45 <= time && time < 75)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
                        yield return new WaitForSecondsRealtime(waitTime);
                        int spawnMonsterPrefabNumber = Random.Range(0, 2);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (75 <= time && time < 115)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
                        yield return new WaitForSecondsRealtime(waitTime);
                        int spawnMonsterPrefabNumber = Random.Range(0, 3);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                }
            }
        }
    }
}
