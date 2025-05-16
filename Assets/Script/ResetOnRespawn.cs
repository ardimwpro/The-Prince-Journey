using UnityEngine;

public class ResetOnRespawn : MonoBehaviour
{
    private bool originalActiveState; // Menyimpan status aktif awal objek

    private void Awake()
    {
        originalActiveState = gameObject.activeSelf; // Simpan status aktif awal objek
    }

    public void ResetObjectState()
    {
        gameObject.SetActive(originalActiveState); // Set status aktif objek sesuai status awal
    }
}
