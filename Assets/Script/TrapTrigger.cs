using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public Trap trap; // Rujuk komponen jebakan yang akan diaktifkan
    public Transform targetPosition; // Posisi tujuan pergerakan jebakan

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trap.ActivateTrap(targetPosition.position); // Aktifkan jebakan dan arahkan ke posisi tujuan
        }
    }
}
