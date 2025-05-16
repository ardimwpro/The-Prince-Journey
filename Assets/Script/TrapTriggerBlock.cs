using UnityEngine;

public class TrapTriggerBlock : MonoBehaviour
{
    public BlockTrap[] blocktraps; // Array dari komponen jebakan yang akan diaktifkan
    public Transform targetPosition; // Posisi tujuan pergerakan jebakan

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (BlockTrap blocktrap in blocktraps)
            {
                blocktrap.ActivateTrap(targetPosition.position); // Aktifkan setiap jebakan dan arahkan ke posisi tujuan
            }
        }
    }
}
