using UnityEngine;

public class AktifSikil : MonoBehaviour
{
    public GameObject objectToActivate; // Game object yang akan diaktifkan

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerSikil"))
        {
            objectToActivate.SetActive(true); // Aktifkan game object
        }
    }
}
