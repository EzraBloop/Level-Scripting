using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public InventoryManager targetInventory;
    public GameObject buttonPrefab;
    public Transform contentParent;

    [ContextMenu("Init UI")]

    private void Awake()
    {
        InitUI();
    }

    public void InitUI()
    {
        Dictionary<InventoryItemSO, InventoryItemData> inventoryRef = targetInventory.inventory;

        foreach(InventoryItemData item in inventoryRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, contentParent);
            tmp.GetComponent<InventoryButton>().InitializeButton(item);
        }
    }
}
