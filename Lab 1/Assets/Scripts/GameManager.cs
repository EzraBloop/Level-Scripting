using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] string profileName;
    [SerializeField] string filePath;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public static string GetName()
    {
        return instance.profileName;
    }
    public static void SetName(string value)
    {
        instance.profileName = value;
    }

    public static string GetFilePath()
    {
        return instance.filePath;
    }

    public static void SetFilePath(string value)
    {
        instance.filePath = value;
    }
   
}
