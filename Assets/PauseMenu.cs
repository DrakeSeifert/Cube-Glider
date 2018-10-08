using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        resetTimeScale();
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        resetTimeScale();
        SceneManager.LoadScene("GameMenu");
    }

    public void QuitGame()
    {
        resetTimeScale();
        SceneManager.LoadScene("Intro");
    }

    void resetTimeScale()
    {
        Time.timeScale = 1f;
    }
}
