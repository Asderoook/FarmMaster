using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject pause;
    private GameObject pauseButton;
    private bool gamePaused;
    public Timer timer;
    private bool stopedggaggame = false;
    
    public void Pause()
    {
        pause.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void Resume()
    {
        pause.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void ToMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }

    public void GameWin()
    {
        if (!stopedggaggame)
        {
            timer.SetSpeedup(0);
            timer.SetText("You win!");
            Pause();
            stopedggaggame = true;
        }
    }

    public void GameLose()
    {
        if (!stopedggaggame)
        {
            timer.SetSpeedup(0);
            timer.SetText("You Lose");
            Pause();
            stopedggaggame = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (gamePaused)
                Resume();
            else
                Pause();
    }

    private void Start()
    {
        ManagerInventory.gameWon += GameWin;
    }

    void Awake()
    {
        pause = transform.Find("pause").gameObject;
        pauseButton = transform.Find("pauseButton").gameObject;
    }
}
