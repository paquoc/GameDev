using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{

    private bool pause = false;
    public GameObject pauseUi;
    // Start is called before the first frame update
    void Start()
    {
        pauseUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }

        pauseUi.SetActive(pause);
        if (pause)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void Resume()
    {
        pause = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pause = false;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
