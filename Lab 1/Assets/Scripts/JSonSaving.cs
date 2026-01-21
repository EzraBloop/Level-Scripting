using UnityEngine;
using System.IO;

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
