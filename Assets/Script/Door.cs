using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
    public Item requiredKey;
    public Transform destinationAfterUnlock;
    public Vector3 newMinValue, newMaxValue;
    public Transform destinationCameraAfterUnlock;

    [Header("Events")]
    public UnityEvent onUnlockEvent;

    public Animator transitionAnim; // Tambahkan referensi ke Animator
    private bool isTransitioning = false;

    private bool playerNearby = false;

    public Button unlockButton; // Referensi tombol Unlock UI

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
            unlockButton.gameObject.SetActive(true); // Aktifkan tombol Unlock saat pemain mendekati pintu.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
            unlockButton.gameObject.SetActive(false); // Matikan tombol Unlock saat pemain menjauhi pintu.
        }
    }

    private void Start()
    {
        unlockButton.onClick.AddListener(TryUnlockDoor); // Menambahkan listener ke tombol Unlock.
        unlockButton.gameObject.SetActive(false); // Matikan tombol Unlock saat awal permainan.
    }

    private void Update()
    {
        if (playerNearby && isLocked && Input.GetKeyDown(KeyCode.O))
        {
            TryUnlockDoor();
        }
    }

    private void TryUnlockDoor()
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

    private IEnumerator LoadLevel()
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

            GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            if (MainCamera != null)
            {
                MainCamera.transform.position = destinationCameraAfterUnlock.position;
            }

            CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.minValue = newMinValue;
                cameraFollow.maxValue = newMaxValue;
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
