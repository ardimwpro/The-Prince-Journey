using UnityEngine;
using UnityEngine.UI;

public class PickupButton : MonoBehaviour
{
    public GameObject itemToPickup; // Tambahkan GameObject item yang akan diambil di Inspector.

    private Button pickupButton;

    private void Start()
    {
        pickupButton = GetComponent<Button>();

        // Tambahkan metode yang akan dipanggil saat tombol "pickup" ditekan.
        pickupButton.onClick.AddListener(PickupItem);
    }

    private void PickupItem()
    {
        // Pastikan Anda memiliki referensi ke instance dari InventorySystem di game Anda.
        InventorySystem inventorySystem = FindObjectOfType<InventorySystem>();

        if (inventorySystem != null && itemToPickup != null)
        {
            // Panggil metode PickUp dari InventorySystem dengan GameObject item sebagai argumen.
            inventorySystem.PickUp(itemToPickup);
        }
    }
}
