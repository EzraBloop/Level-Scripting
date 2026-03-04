using UnityEngine;

public class LoadInfo : MonoBehaviour
{
    public GameState state;
    private LoadInfo instance;

    private void Start()
    {
        OnLoad();
    }
    public void OnLoad()
    {
        state = GameStateManager.Instance.gameState;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
