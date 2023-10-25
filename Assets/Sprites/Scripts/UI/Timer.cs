using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Menu menu;
    private float remainingPercent;
    private float speedup;
    private Text text;

    private void Awake()
    {
        text = gameObject.GetComponent<Text>();
    }

    void Start()
    {
        remainingPercent = 100;
        speedup = 0.3f;
    }

    void Update()
    {
        if (speedup != 0)
        {
            remainingPercent -= Time.deltaTime * speedup;
            var roundedTime = (int)Mathf.Round(remainingPercent);
            text.text = string.Format("{0}%", (roundedTime));
            if (remainingPercent <= 0)
                menu.GameLose();
        }
    }

    public void AddPercent(float percent)
    {
        remainingPercent = Mathf.Min(remainingPercent + percent, 100);
    }

    public void SetSpeedup(float newspeedup)
    {
        speedup = newspeedup;
    }

    public void SetText(string newText)
    {
        text.text = newText;
    }
}
