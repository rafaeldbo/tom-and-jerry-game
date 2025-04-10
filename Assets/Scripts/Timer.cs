using UnityEngine;

public class Timer : MonoBehaviour {
    public static float time {get; set;}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        time = 0; 
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
    }
}
