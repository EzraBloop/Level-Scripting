using System.IO;
using UnityEngine;

public class JSonSaving : MonoBehaviour
{
    public string filePath;
    public GameState profileData;
    string profileName;
    [ContextMenu("JSON Save")]

    public void SaveData()
    {

        string file = "Assets/Resources/save.json";
        string json = JsonUtility.ToJson(GameStateManager.Instance.gameState, true);

        File.WriteAllText(file, json);

    }

    /*    public void SaveData(SaveData profile_)
        {
            string file = filePath + profile_.profileName + ".json";
            string json = JsonUtility.ToJson(profile_, true);
            File.WriteAllText(file, json);
        }*/



    [ContextMenu("JSON Load")]

    public void LoadData()
    {
        string s = "Assets/Resources/save.json";
        if (File.Exists(s))
        {
            string json = File.ReadAllText(s);

            GameStateManager.Instance.gameState = JsonUtility.FromJson<GameState>(json);
        }

        else
        {
            Debug.LogError("Save file not found");
        }
    }

    public void DeleteData()
    {
        string s = "Assets/Resources/save.json";
        if (File.Exists(s))
        {
            File.Delete(s);
        }

        else
        {
            Debug.LogError("Save file not found");
        }
    }
}
