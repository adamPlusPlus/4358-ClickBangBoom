using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;
    public GameObject player;
    private bool paused = false;

    private void Start()
    {
        pauseUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            paused = !paused;
        if(paused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<PlayerControl>().enabled = false;
            player.GetComponentInChildren<Gun>().enabled = false;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;

            player.GetComponent<PlayerControl>().enabled = true;
            player.GetComponentInChildren<Gun>().enabled = true;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
