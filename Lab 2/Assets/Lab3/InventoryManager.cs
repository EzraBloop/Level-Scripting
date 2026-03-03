using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<InventoryItemSO, InventoryItemData> inventory = new Dictionary<InventoryItemSO, InventoryItemData>();

    private void Start()
    {
        
    }

    public void AddItem(InventoryItemSO _itemToAdd)
    {
        if(!inventory.TryAdd(_itemToAdd, _itemToAdd.CreateRuntimeData()))
        {
            inventory[_itemToAdd].quantity++;
        }
    }

    public void RemoveItem(InventoryItemSO _itemToRemove)
    {
        //if(inventory.TryGetValue(_itemToRemove, out InventoryItemData _item)))
        if (inventory[_itemToRemove].quantity > 1)
        {
            inventory[_itemToRemove].quantity--;
            return;
        }
        inventory.Remove(_itemToRemove);
    }
}
