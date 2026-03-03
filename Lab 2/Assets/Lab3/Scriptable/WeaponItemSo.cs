using UnityEngine;

[CreateAssetMenu(fileName = "WeaponItemSo", menuName = "Inventory System/WeaponItemSo")]
public class WeaponItemSo : InventoryItemSO
{
    public int weaponStrengh;
    public int weaponDurability;

    public override InventoryItemData CreateRuntimeData()
    {
        return new WeaponItemData(this);
    }
}
