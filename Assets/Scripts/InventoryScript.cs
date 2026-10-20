using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryScript : MonoBehaviour
{
    InputAction inventoryAction;
    [SerializeField] GameObject InventoryCanvas;
    private bool InventoryActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryAction = InputSystem.actions.FindAction("Inventory");
        InventoryCanvas.SetActive(false);
        InventoryActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryAction.triggered && InventoryActive == false)
        {
            InventoryCanvas.SetActive(true);
            InventoryActive = true;
            Time.timeScale = 0f;
            Debug.Log("Inventory muncul");
        } else if (inventoryAction.triggered && InventoryActive == true)
        {
            InventoryCanvas.SetActive(false);
            InventoryActive = false;
            Time.timeScale = 1f;
            Debug.Log("Inventory hilang");
        }
    }
}
