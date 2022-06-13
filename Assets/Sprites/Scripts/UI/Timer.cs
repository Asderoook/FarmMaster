using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float gameTime;
    public Menu menu;
    private float remainingTime;
    private Text text;

    private void Awake()
    {
        text = gameObject.GetComponent<Text>();
    }

    void Start()
    {
        remainingTime = gameTime;
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
            menu.GameLose();
        var roundedTime = (int)Mathf.Round(remainingTime);
        text.text = string.Format("{0}:{1:D2}", (roundedTime / 60).ToString(), roundedTime % 60);
    }
}
