using UnityEngine;
using TMPro;

public class ManagerUI : MonoBehaviour {
    public TMP_Text TimerText; 
    public TMP_Text ScoreText;
    public TMP_Text LifesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        TimerText.text = ParseTime(Timer.time);
        ScoreText.text = "x" + PlayerManager.score.ToString();
        LifesText.text = "x" + PlayerManager.lifes.ToString();
    }

    private string ParseTime(float time) {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:D2}:{seconds:D2}";
    }
}
