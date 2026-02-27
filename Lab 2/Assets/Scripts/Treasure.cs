using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int value;
    public static MapState Instance;

    private void Awake()
    {
        //Instance = GameStateManager.Instance;
    }

    public void OnPickup()
    {
        Instance.treasureCollected = true;
        Destroy(gameObject);
    }
}
