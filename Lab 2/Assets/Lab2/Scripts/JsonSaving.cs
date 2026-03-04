using System.IO;
using UnityEngine;

public class JSonSaving : MonoBehaviour
{
    public string filePath;
    public GameState profileData;
    public LoadInfo loadInfo;
    string profileName;
    [ContextMenu("JSON Save")]
    private void Awake()
    {
        loadInfo = GameObject.FindGameObjectWithTag("LoadInfo").GetComponent<LoadInfo>();
    }
    private void Start()
    {
        //profileData = GameStateManager.Instance.gameState;
        filePath = Application.persistentDataPath + ".json";
    }
    public void SaveData()
    {
        string file = "Assets/Resources/save.json";

        GameState saveProfile = new GameState();
        string json = JsonUtility.ToJson(GameStateManager.Instance.gameState, true);

        File.WriteAllText(filePath, json);

    }

    [ContextMenu("JSON Load")]

    public void LoadData()
    {
        string s = "Assets/Resources/save.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            //Debug.Log(json);
            loadInfo.state = JsonUtility.FromJson<GameState>(json);
            //Debug.Log(GameStateManager.Instance.gameState);
        }

        else
        {
            Debug.LogError("Save file not found");
        }
    }

    public void DeleteData()
    {
        string s = "Assets/Resources/save.json";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        else
        {
            Debug.LogError("Save file not found");
        }
    }
}
