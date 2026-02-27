using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int value;
    public static GameStateManager Instance;

    private void Awake()
    {
        Instance = GameStateManager.Instance;
    }

    public void OnPickup()
    {
        Instance.TreasureCollected += value;
        Destroy(gameObject);
    }
}
