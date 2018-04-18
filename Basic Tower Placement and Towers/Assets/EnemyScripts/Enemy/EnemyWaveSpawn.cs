using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawn : MonoBehaviour {

    enum GameState {
        SpawnEnemies,
        WaitForWave
    };
    GameState enemyState = GameState.WaitForWave;

    float waveTimer = 0f;
    float timer = 1f;
    int waveNum = 0;
    int enemyToSpawn;

    [SerializeField]
    GameObject enemyPrefab;

    List<GameObject> enemies = new List<GameObject>();

    void Start() {

    }

    void Update() {
        switch (enemyState) {
            case GameState.SpawnEnemies:
                SpawnEnemies();
                break;
            case GameState.WaitForWave:
                if (enemies.Count == 0)
                    WaitForWave(10f);
                break;
        }
    }

    void SpawnEnemies() {
        if (enemyToSpawn > 0) {
            waveTimer += Time.deltaTime;
            if (waveTimer >= timer) {
                waveTimer = 0f;
                Debug.Log("Spawn an enemy");
                enemies.Add((GameObject)Instantiate(enemyPrefab, transform.position, Quaternion.identity));
                enemyToSpawn -= 1;
            }
        }
        if (enemyToSpawn <= 0) {
            waveTimer = 0f;
            Debug.Log("change to waiting");
            enemyState = GameState.WaitForWave;
        }
    }

    void WaitForWave(float timeToWait) {
        if (!(waveTimer >= timeToWait)) {
            waveTimer += Time.deltaTime;
        }
        if (waveTimer >= timeToWait) {
            waveTimer = 0;
            waveNum += 1;
            Debug.Log("change to spawning enemies");
            enemyToSpawn = 5 * waveNum;
            enemyState = GameState.SpawnEnemies;
        }
    }

    public void RemoveEnemyFromList(GameObject enemy) {
        enemies.Remove(enemy);
    }
}
