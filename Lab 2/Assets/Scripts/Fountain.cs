using Unity.VisualScripting;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    public TopDownPlayerMovement player;

    
    public void OnEnable()
    {
        player = GetComponentInParent<TopDownPlayerMovement>();
    }
    public void HealPlayer()
    {

        Debug.Log("Player healed");
        player.Heal();
    }

}
