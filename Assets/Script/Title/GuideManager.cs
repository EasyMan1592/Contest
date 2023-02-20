using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class GuideManager : MonoBehaviour
{

    public static GuideManager instance;
    public GameObject[] Scenes;

    public int page;

    private void Start()
    {
        instance = this;
        page = 1;
    }

    private void Update()
    {
        if(page == 1)
        {
            Scenes[0].SetActive(true);
            Scenes[1].SetActive(false);
            Scenes[2].SetActive(false);
        }
        else if (page == 2)
        {
            Scenes[0].SetActive(false);
            Scenes[1].SetActive(true);
            Scenes[2].SetActive(false);
        }
        else if (page == 3)
        {
            Scenes[0].SetActive(false);
            Scenes[1].SetActive(false);
            Scenes[2].SetActive(true);
        }
    }


}
