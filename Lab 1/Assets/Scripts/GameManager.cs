using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] string profileName;

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
   
}
