using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject gameOverPanel;
    public PlayerManager playerManager; // Reference to PlayerManager
    public GameObject[] objectsToResetWithOriginalPosition;
    public GameObject[] objectsToSetActive;
    private bool isGameOver = false;
    private bool isRespawning = false;
    private Vector3 lastCheckpointPosition;
    public Trap activeTrap;

    private Vector3[] originalObjectPositions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        originalObjectPositions = new Vector3[objectsToResetWithOriginalPosition.Length];
        for (int i = 0; i < objectsToResetWithOriginalPosition.Length; i++)
        {
            originalObjectPositions[i] = objectsToResetWithOriginalPosition[i].transform.position;
        }
    }

    private void Update()
    {
        if (isGameOver && !isRespawning && Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayerAndResetObjects();
            Player playerScript = FindObjectOfType<Player>();
            playerScript.RespawnAndReset();
        }
    }

    public void PlayerDiedAndRespawn()
    {
        
        playerManager.currentPlayer.SetActive(false);
        if (activeTrap != null)
        {
            activeTrap.ResetTrap();
            activeTrap = null;
        }
        StartCoroutine(PlayerDeathDelay());
    }

    IEnumerator PlayerDeathDelay()
{

    // Tunggu sebentar
    yield return new WaitForSeconds(1f); 
      gameOverPanel.SetActive(true);
      isGameOver = true;
   
}

    

    public void SetLastCheckpointPosition(Vector3 position)
    {
        lastCheckpointPosition = position;
    }

    public void RespawnPlayerAndResetObjects()
    {
        isRespawning = true;

        Player playerScript = FindObjectOfType<Player>();
        if (playerScript != null)
        {
            playerScript.RespawnAndReset();
        }

        for (int i = 0; i < objectsToResetWithOriginalPosition.Length; i++)
        {
            GameObject obj = objectsToResetWithOriginalPosition[i];
            if (obj != null)
            {
                obj.transform.position = originalObjectPositions[i];
            }
        }

        foreach (GameObject obj in objectsToSetActive)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        playerManager.currentPlayer.SetActive(true);
        playerManager.currentPlayer.transform.position = lastCheckpointPosition;

        gameOverPanel.SetActive(false);
        isGameOver = false;
        isRespawning = false;
    }

    public Vector3 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }
}