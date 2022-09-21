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

    public void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay > 0)
        {

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = (timeToDisplay % 1 ) *100;
        timerText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
        } else
        {
            timerText.text = string.Empty;
        }
    }

}
