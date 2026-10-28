using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ItemDetailsPanel : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText; 
    [SerializeField] private TextMeshProUGUI itemQtyText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;

    public void Show(ItemDetails item, int quantity)
    {
        if (item == null)
        {
            Clear();
            return;
        }

        itemImage.sprite = item.ItemIcon;
        itemImage.enabled = true;
        itemNameText.text = item.ItemName;
        itemQtyText.text = "Quantity: " + quantity;
        itemDescriptionText.text = item.Description;
    }

    public void Clear()
    {
        itemImage.enabled = false;
        itemNameText.text = "";
        itemQtyText.text = "";
        itemDescriptionText.text = "";
    }
}