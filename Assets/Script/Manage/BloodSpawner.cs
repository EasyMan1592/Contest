using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpawner : MonoBehaviour
{
    public GameObject[] bloodPrefabs; // 0: ������, 1: ������

    [SerializeField] float spawnMinTime;
    [SerializeField] float spawnMaxTime;

    [SerializeField] GameObject spawnPos;
    [SerializeField] Transform spawnPos_;

    bool isCoroutineRunning;

    private void Awake()
    {
        Cheat.OnAllCouroutinePlay += bloodSpawn_Play;
    }

    void Start()
    {
        spawnPos = GameObject.Find("BloodSpawner");
        spawnPos_ = spawnPos.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            Instantiate(bloodPrefabs[1], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.F10))
        {
            Instantiate(bloodPrefabs[0], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity);
        }
    }

    public void bloodSpawn_Play()
    {
        StartCoroutine(bloodSpawn());
    }

    IEnumerator bloodSpawn()
    {
        if (!GameManager.instance_.pause)
        {
            if(!isCoroutineRunning)
            {
                isCoroutineRunning = true;
                float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
                yield return new WaitForSecondsRealtime(waitTime);
                int spawnMonsterPrefabNumber = Random.Range(0, bloodPrefabs.Length);
                Instantiate(bloodPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity);
                isCoroutineRunning = false;
                StartCoroutine(bloodSpawn());
            }
        }
    }
}
