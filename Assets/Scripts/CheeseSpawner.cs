using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheeseSpawner : MonoBehaviour {
    public GameObject cheesePrefab;
    public int spawnCount;
    public float spawnHorinzontalDistance;
    public float spawnVerticalDistance;
    public float spawnRate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        StartCoroutine(SpawnEntities());
    }

    // Update is called once per frame
    void Update() {
        
    }
    private IEnumerator SpawnEntities() {
        yield return new WaitForSeconds(spawnRate);
        if (GameObject.FindGameObjectsWithTag(cheesePrefab.tag).Length < spawnCount) {
            Instantiate(cheesePrefab, transform.position + SpawnPosition(), transform.rotation);
        }
        StartCoroutine(SpawnEntities());
    }
    private Vector3 SpawnPosition() {
        Vector3 randomPosition = new Vector3(Random.Range(-1f, 1f)*spawnHorinzontalDistance, Random.Range(-1f, 1f)*spawnVerticalDistance, 0f);
        if (Physics2D.OverlapPoint(randomPosition) != null) {
            return SpawnPosition();
        }
        return randomPosition;
    }
}
