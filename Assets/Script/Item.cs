using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{    
    public enum InteractionType { NONE, PickUp, Examine, GrabDrop, UnlockDoor }
    public enum ItemType { Staic, Consumables}
    [Header("Attributes")]
    public InteractionType interactType;
    public ItemType type;
    [Header("Examine")]
    public string descriptionText;
    [Header("Custom Events")]
    public UnityEvent customEvent;
    public UnityEvent consumeEvent;

    public Door targetDoor; // Reference ke pintu yang ingin di-unlock oleh item

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    public void Interact()
    {
        switch(interactType)
        {
            case InteractionType.PickUp:
                // Add the object to the PickedUpItems list
                FindObjectOfType<InventorySystem>().PickUp(gameObject);
                // Disable the item
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                // Call the Examine item in the interaction system
                FindObjectOfType<InteractionSystem>().ExamineItem(this);                
                break;
            case InteractionType.GrabDrop:
                // Grab interaction
                FindObjectOfType<InteractionSystem>().GrabDrop();
                break;
            case InteractionType.UnlockDoor:
                UnlockDoor();
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }

        // Invoke the custom event(s)
        customEvent.Invoke();
    }

    // Function to unlock the door
    private void UnlockDoor()
    {
        if (targetDoor != null)
        {
            targetDoor.Unlock(); // Panggil fungsi Unlock pada skrip Door
        }
    }
}
