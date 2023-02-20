using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public static MonsterSpawner instance;

    public GameObject[] monsterPrefabs; // 0: 박테리아, 1: 세균, 2: 바이러스, 3: 암

    [SerializeField] float spawnMinTime;
    [SerializeField] float spawnMaxTime;

    [SerializeField] GameObject spawnPos;
    [SerializeField] Transform spawnPos_;

    bool isCoroutineRunning;

    private void Awake()
    {
        instance = this;
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
                    if (0 <= GameManager.instance_.time && GameManager.instance_.time < 15)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime + 1, spawnMaxTime + 1);
                        yield return new WaitForSecondsRealtime(waitTime);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[0], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (15 <= GameManager.instance_.time && GameManager.instance_.time < 45)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
                        yield return new WaitForSecondsRealtime(waitTime);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[0], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (45 <= GameManager.instance_.time && GameManager.instance_.time < 75)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
                        yield return new WaitForSecondsRealtime(waitTime);
                        int spawnMonsterPrefabNumber = Random.Range(0, 2);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (75 <= GameManager.instance_.time && GameManager.instance_.time < 115)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
                        yield return new WaitForSecondsRealtime(waitTime);
                        int spawnMonsterPrefabNumber = Random.Range(0, 3);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (1000 <= GameManager.instance_.time && GameManager.instance_.time < 1030)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
                        yield return new WaitForSecondsRealtime(waitTime);
                        int spawnMonsterPrefabNumber = Random.Range(0, 3);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (1030 <= GameManager.instance_.time && GameManager.instance_.time < 1060)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
                        yield return new WaitForSecondsRealtime(waitTime);
                        int spawnMonsterPrefabNumber = Random.Range(0, 10);
                        if (spawnMonsterPrefabNumber == 0) spawnMonsterPrefabNumber = 0;
                        else if (spawnMonsterPrefabNumber == 1) spawnMonsterPrefabNumber = 0;
                        else if (spawnMonsterPrefabNumber == 2) spawnMonsterPrefabNumber = 0;
                        else if (spawnMonsterPrefabNumber == 3) spawnMonsterPrefabNumber = 1;
                        else if (spawnMonsterPrefabNumber == 4) spawnMonsterPrefabNumber = 1;
                        else if (spawnMonsterPrefabNumber == 5) spawnMonsterPrefabNumber = 1;
                        else if (spawnMonsterPrefabNumber == 6) spawnMonsterPrefabNumber = 2;
                        else if (spawnMonsterPrefabNumber == 7) spawnMonsterPrefabNumber = 2;
                        else if (spawnMonsterPrefabNumber == 8) spawnMonsterPrefabNumber = 2;
                        else if (spawnMonsterPrefabNumber == 9) spawnMonsterPrefabNumber = 3;
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (1030 <= GameManager.instance_.time && GameManager.instance_.time < 1060)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime - 0.5f);
                        yield return new WaitForSecondsRealtime(waitTime);
                        int spawnMonsterPrefabNumber = Random.Range(0, 7);
                        if (spawnMonsterPrefabNumber == 0) spawnMonsterPrefabNumber = 0;
                        else if (spawnMonsterPrefabNumber == 1) spawnMonsterPrefabNumber = 0;
                        else if (spawnMonsterPrefabNumber == 2) spawnMonsterPrefabNumber = 1;
                        else if (spawnMonsterPrefabNumber == 3) spawnMonsterPrefabNumber = 1;
                        else if (spawnMonsterPrefabNumber == 4) spawnMonsterPrefabNumber = 2;
                        else if (spawnMonsterPrefabNumber == 5) spawnMonsterPrefabNumber = 2;
                        else if (spawnMonsterPrefabNumber == 6) spawnMonsterPrefabNumber = 3;
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                    else if (1060 <= GameManager.instance_.time && GameManager.instance_.time < 1115)
                    {
                        isCoroutineRunning = true;
                        float waitTime = Random.Range(spawnMinTime, spawnMaxTime - 0.5f);
                        yield return new WaitForSecondsRealtime(waitTime);
                        int spawnMonsterPrefabNumber = Random.Range(0, 4);
                        MonsterList.instance.monsters.Add(Instantiate(monsterPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity));
                        isCoroutineRunning = false;
                        StartCoroutine(monsterSpawn());
                    }
                }
            }
        }
    }
}
