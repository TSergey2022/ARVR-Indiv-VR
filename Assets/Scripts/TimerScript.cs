
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static TimerScript Instance { get; private set; }
    
    [SerializeField] private Text timerText;
    
    private Canvas canvas;
    
    private float seconds;
    private bool paused;
    
    
    private void Awake()
    {
        Instance = this;
        canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        if (paused) return;
        timerText.text = FormatTime(seconds);
    }
    
    private static string FormatTime(float seconds)
    {
        var totalSeconds = (int)Mathf.Floor(seconds); // Округляем до целого числа секунд
        var minutes = totalSeconds / 60;
        var remainingSeconds = totalSeconds % 60;

        // Форматируем строку с ведущими нулями
        return $"{minutes:D2}:{remainingSeconds:D2}";
    }

    private void FixedUpdate()
    {
        if (paused) return;
        seconds += Time.deltaTime;
    }

    public void StartTimer()
    {
        paused = false;
    }

    public void ResetTimer()
    {
        seconds = 0;
    }
    
    public void StopTimer()
    {
        paused = true;
    }

    public void Toggle()
    {
        canvas.enabled = !canvas.enabled;
    }

    public void Show()
    {
        canvas.enabled = true;
    }

    public void Hide()
    {
        canvas.enabled = false;
    }
}