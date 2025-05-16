using UnityEngine;
using System.Collections;

public class ObjectNon : MonoBehaviour
{
    public GameObject objectToActivate; // Game object yang akan diaktifkan
    public float activationDelay = 1.0f; // Jeda sebelum mengaktifkan objek (dalam detik)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateWithDelay()); // Memulai coroutine untuk mengaktifkan objek dengan jeda
        }
    }

    private IEnumerator ActivateWithDelay()
    {
        yield return new WaitForSeconds(activationDelay); // Menunggu selama jeda yang ditentukan

        objectToActivate.SetActive(true); // Mengaktifkan game object setelah jeda
    }
}
