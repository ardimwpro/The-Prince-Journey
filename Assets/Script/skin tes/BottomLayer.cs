using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomTrigger : MonoBehaviour
{
     public GameObject objectToActivate;
    // Dipanggil ketika ada objek lain masuk ke dalam trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek lain memiliki layer "Player" (atau layer yang diinginkan)
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Cek apakah ada objek di atas collider
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1.0f);
            
            // Jika tidak ada objek di atas, maka tindakan akan dilakukan
            if (hit.collider == null)
            {
               objectToActivate.SetActive(true); 
            }
        }
    }
}
