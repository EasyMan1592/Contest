using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GoToScoreBoard()
    {
        SceneManager.LoadScene("ScoreBoard");
    }
}
