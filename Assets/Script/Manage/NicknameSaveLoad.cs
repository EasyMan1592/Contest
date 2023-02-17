using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NicknameSaveLoad : MonoBehaviour
{
    public static NicknameSaveLoad instance;

    public InputField PlayerNicknameInput;

    public PlayerData playerData = new PlayerData();

    private void Start()
    {
        LoadPlayerNicknameDataToJson();
    }

    private void OnEnable()
    {
        LoadPlayerNicknameDataToJson();
    }

    void PlayerNicknameEnter()
    {
        string playerNickname = PlayerNicknameInput.text;
        playerData.Nickname.Add(playerNickname);
        playerData.Score.Add(GameManager.instance_.BestScore);
        SavePlayerNicknameDataToJson();
    }

    public void Enter()
    {
        string playerNickname = PlayerNicknameInput.text;
        if (playerNickname.Length > 0)
        {
            PlayerNicknameEnter();
            GameManager.instance_.Next = 2;
        }
    }

    public void skip()
    {
        GameManager.instance_.Next = 2;
    }
    public void SavePlayerNicknameDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.dataPath, "Resources/playerNicknameData.json");
        File.WriteAllText(path, jsonData);
    }

    public void LoadPlayerNicknameDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "Resources/playerNicknameData.json");
        string jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }
}

[System.Serializable]
public class PlayerData
{
    public List<string> Nickname = new List<string>();
    public List<int> Score = new List<int>();
}
