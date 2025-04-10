using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class PlayerManager : MonoBehaviour {
    private const float IMUNITY_DURARION = 3f;
    private const float BLINK_DURATION = 0.4f;
    private const int SCORE_TO_LIFE = 10;
    private const int MAX_LIFES = 3;

    private AudioSource biteSound;
    private AudioSource HitSound;
    private SpriteRenderer spriteRenderer;
    private float imunityTime;
    public static int score {get; set;}
    public static int lifes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        AudioSource[] audios = GetComponents<AudioSource>();
        biteSound = audios[0];
        HitSound = audios[1];
        spriteRenderer = GetComponent<SpriteRenderer>();
        score = 0;
        lifes = MAX_LIFES;
    }
    
    // Update is called once per frame
    void Update() {
        if (imunityTime > 0) {
            imunityTime -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Collectable") {
            biteSound.Play();
            Destroy(other.gameObject);
            score++;
            if (score%SCORE_TO_LIFE == 0 && lifes < MAX_LIFES) lifes++;
        } 
        else if (other.tag == "Enemy") {
            TakeDamage();
        }
        else if (other.tag == "Trap") {
            if (TakeDamage()) Destroy(other.gameObject);
        }
    }

    public bool TakeDamage() {
        if (imunityTime > 0) return false;
        HitSound.Play();
        if (--lifes <= 0) {
            GameOver();
            return true;
        }
        StartCoroutine(Imunity());
        return true;
    }

    private void GameOver() {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetFloat("Time", Timer.time);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync("GameOverMenu");
    }

    private IEnumerator Imunity() {
        Color originalColor = spriteRenderer.color;
        Color imunityColor = new Color(255, 0, 0, 1f);
        imunityTime = IMUNITY_DURARION;
        for (int i = 0; i < IMUNITY_DURARION/BLINK_DURATION; i++) {
            spriteRenderer.color = imunityColor;
            yield return new WaitForSeconds(BLINK_DURATION/2);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(BLINK_DURATION/2);
        }
    }   
}