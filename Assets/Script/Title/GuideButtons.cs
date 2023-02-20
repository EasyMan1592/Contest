using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuideButtons : MonoBehaviour
{
    public GameObject GuideDisplay;

    public void guideOn()
    {
        GuideDisplay.SetActive(true);
    }

    public void guideOff()
    {
        GuideManager.instance.page = 1;
        GuideDisplay.SetActive(false);
    }

    public void page_1()
    {
        GuideManager.instance.page = 1;
    }

    public void page_2()
    {
        GuideManager.instance.page = 2;
    }

    public void page_3()
    {
        GuideManager.instance.page = 3;
    }



}
