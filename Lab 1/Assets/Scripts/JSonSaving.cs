using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSonSaving : MonoBehaviour
{
    public string filePath;
    public SaveData profileData;
    string profileName;
    string file;
    int highScore;

    [ContextMenu("JSON Save")]

    private void Awake()
    {
        filePath = Application.persistentDataPath;
        profileName = GameManager.GetName();
        file = filePath + profileName + ".json";
    }
    private void Start()
    {
        //SaveData();
        
    }
    public void SaveData(string profileName, int highScore, GhostData ghostData)
    {
        SaveData saveProfile = new SaveData(profileName, highScore, ghostData);
        string json = JsonUtility.ToJson(saveProfile, true);
  

        File.WriteAllText(file, json);
    }

    [ContextMenu("JSON Load")]

    public SaveData LoadData()
    {
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            Debug.Log($"Json file {json}");

            profileData = JsonUtility.FromJson<SaveData>(json);
            return profileData;
        }

        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }

    public void DeleteData()
    {
        if(File.Exists(file))
        { 
            File.Delete(file); 
        }
        else
        {
            Debug.LogError("Save file not found");
        }
    }
    public void UpdateProfileName(string profileName_)
    {
        profileName = profileName_;
    }
}


[Serializable]
public class SaveData
{
    public string profileName;
    public int highScore;
    public GhostData ghostData;


    public SaveData(string profileName_, int highScore_, GhostData ghostData_)
    {
        profileName = profileName_;
        highScore = highScore_;
        ghostData = ghostData_;
    }
}
