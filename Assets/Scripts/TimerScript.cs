using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public int seconds;
    public int minutes;
    public static int Second;
    void Start()
    {
        AddToSeconds();
    }

    private void AddToSeconds()
    {
        seconds++;
        Second = seconds;
        if (seconds > 59)
        {
            minutes++;
            seconds = 0;
        }

        timerText.text = $"{minutes:0#}:{seconds:0#}";
        Invoke(nameof(AddToSeconds), 1);
    }

    public void StopTimer()
    {
        CancelInvoke(nameof(AddToSeconds));
        timerText.gameObject.SetActive(false);
    }
}