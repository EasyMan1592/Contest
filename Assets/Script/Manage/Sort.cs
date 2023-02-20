using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.IO;

public class Sort : MonoBehaviour
{
    public PlayerData playerData1 = new PlayerData();

    private void Start()
    {
        LoadPlayerNicknameDataToJson();
        int cnt = 0;
        foreach (int a in playerData1.Score)
        {
            cnt++;
        }

        string sTemp;
        int iTemp;
        for (int i = 0; i < cnt; i++)
        {
            for (int j = 0; j < cnt - i - 1; j++)
            {
                if (playerData1.Score[j] < playerData1.Score[j + 1])
                {
                    iTemp = playerData1.Score[j];
                    playerData1.Score[j] = playerData1.Score[j + 1];
                    playerData1.Score[j + 1] = iTemp;

                    sTemp = playerData1.Nickname[j];
                    playerData1.Nickname[j] = playerData1.Nickname[j + 1];
                    playerData1.Nickname[j + 1] = sTemp;
                }
            }
        }
    }

    private void Update()
    {
        if ((playerData1.Nickname.Count < 5) || (GameManager.instance_.BestScore > playerData1.Score[4]))
        {
            GameManager.instance_.inTop5 = true;
        }
        else
        {
            GameManager.instance_.inTop5 = false;
        }
    }

    public void LoadPlayerNicknameDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "Resources/playerNicknameData.json");
        string jsonData = File.ReadAllText(path);
        playerData1 = JsonUtility.FromJson<PlayerData>(jsonData);
    }
}

