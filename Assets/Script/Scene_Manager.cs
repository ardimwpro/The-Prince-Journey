using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager Instance { get; private set; }

    int Saved_scene;
    int Scene_index;

    public Animator transitionAnim; // Reference to the transition animator

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void new_game()
    {
        StartCoroutine(LoadSceneWithTransition(1));
    }

    public void Load_Saved_Scene()
    {
        Saved_scene = PlayerPrefs.GetInt("Saved");

        if (Saved_scene != 0)
        {
            StartCoroutine(LoadSceneWithTransition(Saved_scene));
        }
    }

    public void SaveGame()
    {
        Scene_index = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Saved", Scene_index);
        PlayerPrefs.Save();
    }

    public void Save_and_Exit()
    {
        SaveGame(); // Call the SaveGame method here
        StartCoroutine(LoadSceneWithTransition(0));
    }

    // Loading scene with transition
    IEnumerator LoadSceneWithTransition(int sceneIndex)
    {
        transitionAnim.SetTrigger("End"); // Start transition animation
        yield return new WaitForSeconds(2); // Wait for transition animation to finish

        SceneManager.LoadSceneAsync(sceneIndex);

        // Optionally, you can set a delay before starting the transition back in
        yield return new WaitForSeconds(0.5f);

        transitionAnim.SetTrigger("Start"); // Start transition animation
    }
}
