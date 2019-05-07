using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public GameObject deathMenu;
    public GameAudio gameAudio;
    public GameObject player;


    // Update is called once per frame

    public Button restartButt;
    public Button quitButt;

    void Start()
    {


        restartButt = restartButt.GetComponent<Button>();
        restartButt.onClick.AddListener(Restart);
        quitButt = quitButt.GetComponent<Button>();
        quitButt.onClick.AddListener(QuitMenu);
    }

    void Update()
    {
        if (!player.GetComponent<PlayerController>().alive)
        {
            deathMenu.SetActive(true);
            GetComponent<PauseMenu>().enabled = false;
        }

    }

    public void Restart()
    {
        Grid.visitedCounter = 0;
        SceneManager.LoadScene("MainGame");
    }

    public void QuitMenu()
    {
        Debug.Log("QUIT");
        Grid.ClearVisited();
        Application.Quit();
    }
}
