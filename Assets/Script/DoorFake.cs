using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorFake : MonoBehaviour
{
    public bool isLocked = true;
    public Item requiredKey;
    public Transform destinationAfterUnlock;
    public Transform destinationCameraAfterUnlock;
    

    public GameObject[] objectsToResetWithOriginalPosition; // Objek yang perlu di-reset posisinya
    public GameObject[] objectsToSetActive; // Objek yang

    public GameObject gameOverPanel;
    public GameObject player;
    private bool isGameOver = false;
    private bool isRespawning = false;
    private Vector3 lastCheckpointPosition;
    
    [Header("Events")]
    public UnityEvent onUnlockEvent;
    private Vector3[] originalObjectPositions;
    public Animator transitionAnim; // Tambahkan referensi ke Animator
    private bool isTransitioning = false;
    
    private bool playerNearby = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    private void Update()
    {
        if (playerNearby && isLocked && Input.GetKeyDown(KeyCode.O))
        {
            InventorySystem inventory = FindObjectOfType<InventorySystem>();
            if (inventory != null && inventory.HasItem(requiredKey.gameObject))
            {
                StartCoroutine(LoadLevel()); // Ubah pemanggilan
            }
            else
            {
                Debug.Log("Door Locked");
            }
        }
        if (isGameOver && !isRespawning && Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayerAndResetObjects();
        }
    }

        public void PlayerDiedAndRespawn()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        player.gameObject.SetActive(false); // Deactivate the player GameObject
    }

    public void SetLastCheckpointPosition(Vector3 position)
    {
        lastCheckpointPosition = position;
    }

    private void RespawnPlayerAndResetObjects()
    {
        isRespawning = true;

        Player playerScript = FindObjectOfType<Player>();
        if (playerScript != null)
        {
            playerScript.RespawnAndReset();
        }

        // Reset posisi objek-objek yang di-reset
        for (int i = 0; i < objectsToResetWithOriginalPosition.Length; i++)
        {
            GameObject obj = objectsToResetWithOriginalPosition[i];
            if (obj != null)
            {
                obj.transform.position = originalObjectPositions[i];
            }
        }

        // Aktifkan atau nonaktifkan objek-objek yang sesuai
        foreach (GameObject obj in objectsToSetActive)
        {
            if (obj != null)
            {
                obj.SetActive(false); // Atur sesuai kebutuhan
            }
        }

        player.SetActive(true);
        player.transform.position = lastCheckpointPosition;

        gameOverPanel.SetActive(false);
        isGameOver = false;
        isRespawning = false; // Selesai proses respawn
    }

    public Vector3 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }

    IEnumerator LoadLevel()
    {
        if (!isTransitioning)
        {
            isTransitioning = true;

            // Memulai animasi transisi keluar
            transitionAnim.SetTrigger("End");
            yield return new WaitForSeconds(2);

            Unlock();
            InventorySystem inventory = FindObjectOfType<InventorySystem>();
            if (inventory != null)
            {
                inventory.RemoveItem(requiredKey.gameObject);
                Debug.Log("Door Unlocked");
            }

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = destinationAfterUnlock.position;
            }

            // Memulai animasi transisi masuk
            transitionAnim.SetTrigger("Start");
            yield return new WaitForSeconds(2);

            isTransitioning = false;
        }
    }

    public void Unlock()
    {
        isLocked = false;
        onUnlockEvent.Invoke();
    }
}
