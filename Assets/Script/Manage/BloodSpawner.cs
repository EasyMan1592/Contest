using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpawner : MonoBehaviour
{
    public GameObject[] bloodPrefabs; // 0: ¹éÇ÷±¸, 1: ÀûÇ÷±¸

    [SerializeField] float spawnMinTime;
    [SerializeField] float spawnMaxTime;

    [SerializeField] GameObject spawnPos;
    [SerializeField] Transform spawnPos_;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GameObject.Find("BloodSpawner");
        spawnPos_ = spawnPos.GetComponent<Transform>();
        StartCoroutine(bloodSpawn());
    }

    IEnumerator bloodSpawn()
    {
        float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
        yield return new WaitForSecondsRealtime(waitTime);
        int spawnMonsterPrefabNumber = Random.Range(0, bloodPrefabs.Length);
        Instantiate(bloodPrefabs[spawnMonsterPrefabNumber], new Vector2(spawnPos_.position.x + Random.Range(-2.5f, 2.5f), spawnPos_.position.y), Quaternion.identity);
        StartCoroutine(bloodSpawn());
    }
}
