using System;
using System.IO;
using UnityEngine;

public class JSonSaving : MonoBehaviour
{
    public string filePath;
    public SaveData profileData;
    string profileName;
    [ContextMenu("JSON Save")]

    public void SaveData()
    {
        SaveData saveProfile = new SaveData("Sujan", 1111);
        string file = filePath + profileName + ".json";
        string json = JsonUtility.ToJson(saveProfile, true);

        Debug.Log(filePath);
        File.WriteAllText(filePath, json);
    }

    [ContextMenu("JSON Load")]

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            profileData = JsonUtility.FromJson<SaveData>(json);
        }

        else
        {
            Debug.LogError("Save file not found");
        }
    }
}

[Serializable]
public class SaveData
{
    public string profileName;
    public int highScore;
    public GhostData ghostData;

    public SaveData(string profileName_, int highScore_)
    {
        profileName = profileName_;
        highScore = highScore_;
    }
}
