using UnityEngine;

public class TrapManager : MonoBehaviour {

    private float lifeTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        lifeTime = 5f;
    }

    // Update is called once per frame
    void Update() {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) {
            Destroy(gameObject);
        }
    }
}
