using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stage1 : MonoBehaviour
{
    public GameObject bossBullet;
    public GameObject bossBullet_;
    int patternLength;
    int workingPattern;
    bool isPatternWorking;

    public GameObject[] monsterPrefabs; // 0:박테리아  1:세균  2:바이러스  3:암


    // Start is called before the first frame update
    void Start()
    {
        patternLength = 4;
        isPatternWorking = false;
        workingPattern = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(BossManager.instance_.bossFighting)
        {
            if (!isPatternWorking)
            {
                switch (workingPattern)
                {
                    case -1:
                        startPattern();
                        StartCoroutine(patternDelay(2f));
                        break;
                    case 0:
                        StartCoroutine(triplCircleShot());
                        StartCoroutine(patternDelay(3f));
                        break;
                    case 1:
                        StartCoroutine(quintupleFrontShot());
                        StartCoroutine(patternDelay(3f));
                        break;
                    case 2:
                        StartCoroutine(zigzagShot());
                        StartCoroutine(patternDelay(3f));
                        break;


                    case 3:
                        int a = Random.Range(0, 3);
                        switch(a)
                        {
                            case 0:
                                spawn_Bacteria();
                                StartCoroutine(patternDelay(2f));
                                break;
                            case 1:
                                spawn_Germ();
                                StartCoroutine(patternDelay(2f));
                                break;
                            case 2:
                                spawn_Virus();
                                StartCoroutine(patternDelay(3f));
                                break;
                        }
                        break;

                }
            }
            

        }
        
    }

    void startPattern()
    {
        isPatternWorking = true;
    }


    IEnumerator triplCircleShot()
    {
        isPatternWorking = true;
        int a = 0;
        int plusAmount = 30;
        for(int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 12; i++)
            {
                Instantiate(bossBullet, transform.position, Quaternion.Euler(0, 0, a));
                a += plusAmount;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator quintupleFrontShot()
    {
        isPatternWorking = true;
        int a = 150;
        int plusAmount = 30;
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(bossBullet, transform.position, Quaternion.Euler(0, 0, a));
                a += plusAmount;
            }

            if (j % 2 == 0)
            {
                a = 135;
            }
            else
            {
                a = 150;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator zigzagShot()
    {
        isPatternWorking = true;
        for (int i = 0; i < 12; i++)
        {
            Instantiate(bossBullet_, transform.position, Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(0.3f);
        }
    }

     void spawn_Bacteria()
    {
        isPatternWorking = true;
        for (int i = 0; i < 2; i++)
        {
            Instantiate(monsterPrefabs[0], new Vector2(transform.position.x + Random.Range(-2.5f, 2.5f), transform.position.y), Quaternion.identity) ;
        }
    }

    void spawn_Germ()
    {
        isPatternWorking = true;
        for (int i = 0; i < 1; i++)
        {
            Instantiate(monsterPrefabs[1], new Vector2(transform.position.x + Random.Range(-2.5f, 2.5f), transform.position.y - 1.5f), Quaternion.identity);
        }
    }

    void spawn_Virus()
    {
        isPatternWorking = true;
        for (int i = 0; i < 2; i++)
        {
            Instantiate(monsterPrefabs[2], new Vector2(transform.position.x + Random.Range(-2.5f, 2.5f), transform.position.y), Quaternion.identity);
        }
    }

    IEnumerator patternDelay(float newdelaytime)
    {
        yield return new WaitForSecondsRealtime(newdelaytime);
        isPatternWorking = false;
        workingPattern = Random.Range(0, patternLength);
        
    }

}
