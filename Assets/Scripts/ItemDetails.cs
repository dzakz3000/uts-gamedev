using UnityEngine;

[CreateAssetMenu(fileName = "ItemDetails", menuName = "Scriptable Objects/ItemDetails")]

[System.Serializable]
public class ItemDetails : ScriptableObject
{
     [SerializeField] private string itemName;
    [SerializeField] private int quantity = 1;
    [SerializeField] private Sprite itemIcon;

    public string ItemName => itemName;
    public int Quantity => quantity;
    public Sprite ItemIcon => itemIcon;
}