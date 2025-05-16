using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void Mulai()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void TesLevel()
    {
        SceneManager.LoadScene("Level6");
        Time.timeScale = 1f;
    }


    public void Setting()
    {
        SceneManager.LoadScene("SETTINGS");
        Time.timeScale = 1f;
    }


    public void Credit()
    {
        SceneManager.LoadScene("CREDITS");
        Time.timeScale = 1f;
    }


    public void Help()
    {
        SceneManager.LoadScene("HELP");
        Time.timeScale = 1f;
    }

    public void Back()
    {
        SceneManager.LoadScene("MENU");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
       
    }

}