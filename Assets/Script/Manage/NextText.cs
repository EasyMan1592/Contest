using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextText : MonoBehaviour
{
    public Text text;

    private void OnEnable()
    {
        StartCoroutine(textOut());
    }

    IEnumerator textOut()
    {
        float fadeCount = 0;
        while (fadeCount <= 1f)
        {
            fadeCount += 0.001f;
            yield return null;
            text.color = new Color(text.color.r, text.color.g, text.color.b, fadeCount);
        }
        fadeCount = 1;
        while (fadeCount >= 0f)
        {
            fadeCount -= 0.001f;
            yield return null;
            text.color = new Color(text.color.r, text.color.g, text.color.b, fadeCount);
        }
        StartCoroutine(textOut());
    }

}