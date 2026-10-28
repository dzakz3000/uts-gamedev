using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // Item Data
    public ItemDetails itemDetails; // <-- TAMBAHAN: Variabel untuk menyimpan data item
    public string itemName;
    public int itemQuantity; // Ini nama variabel untuk jumlah (bukan quantity)
    public Sprite itemIcon;
    public bool isFull;

    // Item Slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    [SerializeField] private int MaxStackSize = 99;

    // Interactive item slot
    [SerializeField] public GameObject SelectedPanel;
    public bool isItemSelected;
    public InventoryManager inventoryManager;

    public void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
    
    public void AddItem(ItemDetails item)
    {
        itemDetails = item; // <-- TAMBAHAN: Simpan data item saat dimasukkan ke slot
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
        itemImage.enabled = true; // Pastikan gambar muncul
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightClick();
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            LeftClick();
        }
    }

    private void RightClick()
    {
        if (isFull)
        {
            Debug.Log("Right Clicked");
        }
    }

    private void LeftClick()
    {
        // PERBAIKAN: Lempar tugas klik ini ke InventoryManager
        if (inventoryManager != null)
        {
            inventoryManager.SelectSlot(this);
            Debug.Log("Left Clicked");
        }
    }
}