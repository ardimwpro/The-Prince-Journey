using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottes : MonoBehaviour
{
     public GameObject objectToActivate;
    // Dipanggil ketika ada objek lain masuk ke dalam trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek lain memiliki tag "Player" (atau tag yang sesuai)
        if (other.CompareTag("Player"))
        {
            // Dapatkan arah relatif antara objek lain dan collider yang memicu trigger
            Vector2 direction = other.transform.position - transform.position;

            // Cek apakah arah relatif lebih mendekati bawah (nilai y lebih kecil)
            if (direction.y < 0)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
