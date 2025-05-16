using UnityEngine;

public class TrapBack : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan jebakan
    private bool isMoving = false; // Status pergerakan jebakan
    private Vector3 targetPosition; // Posisi tujuan pergerakan jebakan
    private Vector3 originalPosition; // Posisi awal jebakan

    private void Start()
    {
        originalPosition = transform.position; // Simpan posisi awal jebakan
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveToTarget(); // Jika jebakan sedang bergerak, lakukan pergerakan
        }
    }

    public void ActivateTrap(Vector3 target)
    {
        targetPosition = target; // Set posisi tujuan pergerakan jebakan
        isMoving = true; // Aktifkan pergerakan jebakan
    }

    private void MoveToTarget()
    {
        // Gerakkan jebakan menuju posisi tujuan
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Cek apakah jebakan sudah mencapai posisi tujuan
        if (transform.position == targetPosition)
        {
            isMoving = false; // Berhenti pergerakan
        }
    }

    public void MoveToStart()
    {
        // Gerakkan jebakan menuju posisi awal
        transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);

        // Cek apakah jebakan sudah mencapai posisi awal
        if (transform.position == originalPosition)
        {
            isMoving = false; // Berhenti pergerakan
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDiedAndRespawn();
        }
    }
}
