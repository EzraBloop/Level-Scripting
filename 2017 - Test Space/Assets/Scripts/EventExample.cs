using UnityEngine;
using UnityEngine.Events;

public class EventExample : MonoBehaviour
{
    public UnityEvent onCoinCollected;
    public int coinCount;

    [ContextMenu("coin collected")]
    public void CollectCoin()
    {
        coinCount++;
        onCoinCollected?.Invoke(); // ? is an error catch, invoke will cause all events in list to activate 
    }
}
