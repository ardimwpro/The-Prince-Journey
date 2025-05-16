using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Memanggil fungsi di GameManager untuk mengatur posisi checkpoint
            GameManager.Instance.SetLastCheckpointPosition(transform.position);
            // Menandai bahwa checkpoint telah diaktifkan
             AudioManager.Instance.PlaySFX("Finish");
            Scene_Manager.Instance.SaveGame();  // Menyimpan permainan
            Debug.Log("Check");
        }
    }
}
