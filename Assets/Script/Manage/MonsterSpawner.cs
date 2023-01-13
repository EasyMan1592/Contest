using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 0: ���׸���, 1: ����, 2: ���̷���, 3: ��

    [SerializeField] float spawnMinTime;
    [SerializeField] float spawnMaxTime;

    [SerializeField] GameObject spawnPos;
    [SerializeField] Transform spawnPos_;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GameObject.Find("MonsterSpawner");
        spawnPos_ = spawnPos.GetComponent<Transform>();
        StartCoroutine(monsterSpawn());
    }
    
    IEnumerator monsterSpawn()
    {
        if(!BossManager.instance_.bossFighting)
        {
            float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
            yield return new WaitForSecondsRealtime(waitTime);
            int spawnMonsterPrefabNumber = Random.Range(0, monsterPrefabs.Length);
            Instantiate(monsterPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity);
            StartCoroutine(monsterSpawn());
        }
    }
}
