using TMPro;
using UnityEngine;

public class TimerTextController : MonoBehaviour
{
    private TextMeshProUGUI timerText;

    private int timerValue;

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    public void SetTimerValue(int value)
    {
        if (value < 0)
        {
            timerValue = 0;
        }
        else
        {
            timerValue = value;
        }

        UpdateText();
    }

    private void UpdateText()
    {
        timerText.SetText("Ready: {0}", timerValue);
    }
}
