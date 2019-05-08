using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    public GameAudio gameAudio;
    public Scene musicScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == true)
            {
                Resume();
                gameAudio.PlayAudio();
            }
            else
            {
                Pause();
                gameAudio.PauseAudio();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Utilities.ResetSettings();
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void QuitMenu()
    {
        Application.Quit();
    }
}
