using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrapSpawner : MonoBehaviour {
    public GameObject TrapPrefab;
    private int spawnCount = 0;
    public int maxSpawnCount;
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
        spawnCount = (spawnCount > maxSpawnCount) ? maxSpawnCount : (int) (Timer.time/30);
        if (GameObject.FindGameObjectsWithTag(TrapPrefab.tag).Length < spawnCount) {
            Vector3 randomPosition = new Vector3(Random.Range(-1f, 1f)*spawnHorinzontalDistance, Random.Range(-1f, 1f)*spawnVerticalDistance, 0f);
            Instantiate(TrapPrefab, transform.position + randomPosition, transform.rotation);
        }
        StartCoroutine(SpawnEntities());
    }
}
