using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject levels;
    public GameObject info;

    public void Play()
    {
        menu.SetActive(false);
        info.SetActive(false);
        levels.SetActive(true);
    }

    public void PlayLevel(int number)
    {
        SceneManager.LoadScene("Game" + number);
    }

    public void Info()
    {
        menu.SetActive(false);
        levels.SetActive(false);
        info.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        levels.SetActive(false);
        info.SetActive(false);
        menu.SetActive(true);
    }

    void Awake()
    {
        menu = transform.Find("menu").gameObject; 
    }
}
