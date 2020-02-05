using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject panel;

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Button pressed");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        AudioListener.pause = false;
        panel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        AudioListener.pause = false;
        panel.SetActive(false);
    }
}
