using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Item Data
    public string itemName;
    public int itemQuantity;
    public Sprite itemIcon;
    public bool isFull;

    // Item Slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    [SerializeField] private int MaxStackSize = 99;
    
   public void AddItem(ItemDetails item)
    {
        itemName = item.ItemName;
        
        itemIcon = item.ItemIcon;
        isFull = true;
        AddQuantity(item.Quantity);
    }

    public bool CanStackWith(string otherItemName)
    {
        return !isFull && itemName == otherItemName;
    }

    public void AddQuantity(int amount){
        itemQuantity += amount;
        isFull = itemQuantity >= MaxStackSize;

        quantityText.text = itemQuantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemIcon;
    }
    
}
