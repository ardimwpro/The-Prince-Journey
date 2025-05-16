using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject pauseMenuScreen;
    public CameraFollow cameraFollow;
    public GameObject[] playerPrefabs;
    public GameObject currentPlayer;

    private void Awake()
    {
        int characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        SetCharacter(characterIndex);
    }

    void Update()
    {

    }

    public void ReplayLevel()
{
    Time.timeScale = 1;
    
    if (currentPlayer != null)
    {
        Destroy(currentPlayer);
    }
    
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MENU");
        Time.timeScale = 1f;
    }

    public void ChangeCharacter(int characterIndex)
    {
        SetCharacter(characterIndex);
    }

    private void SetCharacter(int characterIndex)
    {
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }

        currentPlayer = Instantiate(playerPrefabs[characterIndex], transform.position, Quaternion.identity);
        cameraFollow.target = currentPlayer.transform;

        transform.parent = currentPlayer.transform;
         transform.localPosition = Vector3.zero;
    }
}