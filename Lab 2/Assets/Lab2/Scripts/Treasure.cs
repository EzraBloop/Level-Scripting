using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int value;
    public int mapID;
    public GameStateManager Instance;
    public MapState state;

    private void Awake()
    {
        
    }

    public void OnPickup()
    {
        //foreach (MapState states in Instance.gameState.mapStates)
        //{
        //    if(states.mapID == mapID)
        //    {
        //        states.treasureCollected = true;
        //    }
        //}
       
        Destroy(gameObject);
    }
}
