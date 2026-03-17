using UnityEngine;
using UnityEngine.InputSystem;

public class ChestManager : MonoBehaviour
{
    public GameObject chestInventory;
    private bool chestOpened, playerInRange = false;


    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && playerInRange)
        {
            Debug.Log("Opened");
            if (!chestOpened)
            {
                chestOpened = true;
                chestInventory.SetActive(true);
            }
            else
            {
                chestOpened = false;
                chestInventory.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("In range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("out of range");
        playerInRange = false;
        if (chestOpened)
        {
            chestOpened = false;
            chestInventory.SetActive(false);
        }
    }
    
}
