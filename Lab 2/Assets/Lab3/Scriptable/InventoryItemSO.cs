using UnityEngine;

[CreateAssetMenu(fileName = "IventoryItemSO", menuName = "Inventory System/IventoryItemSO")]
public abstract class InventoryItemSO : ScriptableObject
{
    public string itemName;
    public string flavourText;
    public Sprite icon;

    public abstract InventoryItemData CreateRuntimeData();

}
