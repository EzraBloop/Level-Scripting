using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int value;
    public GameStateManager Instance;
    public MapState state;

    private void Awake()
    {
        
    }

    public void OnPickup()
    {
        state.treasureCollected = true;
        Destroy(gameObject);
    }
}
