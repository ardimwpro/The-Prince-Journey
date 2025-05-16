using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorScene : MonoBehaviour
{
    public bool isLocked = true;
    public Item requiredKey;
    public Animator transitionAnim;
    public UnityEvent onUnlockEvent;
    public string scenetujuan;
    public DoorUnlockUI doorUnlockUI;
    public Button unlockButton; // Referensi tombol Unlock UI

    private bool isTransitioning = false;
    private bool playerNearby = false;

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
        unlockButton.onClick.AddListener(UnlockDoor); // Menambahkan listener ke tombol Unlock.
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
            StartCoroutine(LoadLevel());
        }
        else
        {
            if (doorUnlockUI != null)
            {
                AudioManager.Instance.PlaySFX("Lock");
                doorUnlockUI.ShowMessage("Door is locked!");
            }
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
                AudioManager.Instance.PlaySFX("Tele");
            }

            // Lakukan perpindahan antar scene di sini
            SceneManager.LoadScene(scenetujuan);

            isTransitioning = false;
        }
    }

    public void Unlock()
    {
        isLocked = false;
        onUnlockEvent.Invoke();
    }

    public void StartTransition()
    {
        // Memulai animasi transisi masuk
        transitionAnim.SetTrigger("Start");
        StartCoroutine(StartTransitionDelay());
    }

    private IEnumerator StartTransitionDelay()
    {
        yield return new WaitForSeconds(2);
        isTransitioning = false;
    }

    public void UnlockDoor()
    {
        if (isLocked)
        {
            TryUnlockDoor();
        }
    }
}
