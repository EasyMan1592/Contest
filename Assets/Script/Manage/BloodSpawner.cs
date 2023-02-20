using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpawner : MonoBehaviour
{
    public static BloodSpawner instance;
    public GameObject[] bloodPrefabs; // 0: ÀûÇ÷±¸, 1: ¹éÇ÷±¸

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
            if (!GameManager.instance_.stage2clear)
            {
                if (!isCoroutineRunning)
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
}