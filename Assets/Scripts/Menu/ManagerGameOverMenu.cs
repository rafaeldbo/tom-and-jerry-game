using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ManagerGameOverMenu : MonoBehaviour {
    public TMP_Text TimerText; 
    public TMP_Text ScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        TimerText.text = ParseTime(PlayerPrefs.GetFloat("Time"));
        ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    public void PlayAgain() {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void MainMenu() {
        SceneManager.LoadSceneAsync("StartMenu");
    }

    private string ParseTime(float time) {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:D2}:{seconds:D2}";
    }
}

