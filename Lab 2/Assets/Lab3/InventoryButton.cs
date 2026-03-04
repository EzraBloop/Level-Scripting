using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text flavourText;
    public Image icon;
    public TMP_Text quantityDisplay;

    public void InitializeButton(InventoryItemData inventoryItemData)
    {
        itemName.text = inventoryItemData.itemName;
        flavourText.text = inventoryItemData.flavourText;
        quantityDisplay.text = inventoryItemData.quantity.ToString();
        icon.sprite = inventoryItemData.icon;
    }
}
