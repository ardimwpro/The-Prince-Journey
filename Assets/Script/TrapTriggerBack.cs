using UnityEngine;

public class TrapTriggerBack : MonoBehaviour
{
    public TrapBack trapback; // Rujuk komponen jebakan yang akan diaktifkan
    public Transform targetPosition; // Posisi tujuan pergerakan jebakan
    private bool playerInRange = false; // Status pemain berada dalam jangkauan pemicu

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // Pemain berada dalam jangkauan pemicu
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Pemain tidak lagi berada dalam jangkauan pemicu
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            trapback.ActivateTrap(targetPosition.position); // Aktifkan jebakan dan arahkan ke posisi tujuan
        }
        else
        {
            trapback.MoveToStart(); // Gerakkan jebakan kembali ke posisi awal jika pemain tidak dalam jangkauan
        }
    }
}
