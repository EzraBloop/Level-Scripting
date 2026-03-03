using UnityEngine;

public class ArmorItemData : InventoryItemData
{
    public int armorRating;
    public ArmorSlot armorSlot;

    public ArmorItemData (ArmourItemSO _config)
    {
        this.config = _config;
        this.flavourText = _config.flavourText;
        this.itemName = _config.itemName;
        this.icon = _config.icon;
        this.armorRating = _config.armorRating;
        this.armorSlot = _config.armorSlot;
        quantity = 1;
    }
}
