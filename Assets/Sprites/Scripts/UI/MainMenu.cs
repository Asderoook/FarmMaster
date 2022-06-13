using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Info()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {

    }

    void Awake()
    {
        menu = transform.Find("menu").gameObject; 
    }
}
