using UnityEngine;

public class ObjectActive : MonoBehaviour
{
    public GameObject objectToActivate; // Game object yang akan diaktifkan

    private void OnTriggerEnter2D(Collider2D other)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1.0f);

        if (other.CompareTag("Player"))
        {
            objectToActivate.SetActive(true); // Aktifkan game object
        }
    }
}
