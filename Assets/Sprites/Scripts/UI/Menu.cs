using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject pause;
    private GameObject pauseButton;
    private bool gamePaused;

    
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
        Debug.Log("Win");
    }

    public void GameLose()
    {
        Debug.Log("Lose");
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
