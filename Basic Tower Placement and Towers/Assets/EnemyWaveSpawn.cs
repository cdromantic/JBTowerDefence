using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawn : MonoBehaviour {
    int waveNum = 1;
    int enemyToSpawn;
    [SerializeField]
    GameObject enemyPrefab;

    List<GameObject> enemies = new List<GameObject>();

	void Start () {
		
	}
	
	void Update () {
        if (!IsInvoking("SpawnEnemies")) {
            InvokeRepeating("SpawnEnemies", 5f, 2f);
            enemyToSpawn = 5 * waveNum;
         }
        if (enemyToSpawn == 0) {
            CancelInvoke("SpawnEnemies");
        }
	}
    void SpawnEnemies() {
        if (enemyToSpawn != 0) {
            enemies.Add((GameObject)Instantiate(enemyPrefab, transform.position, Quaternion.identity));
        }
    }
    public void RemoveEnemyFromList(GameObject enemy) {
        enemies.Remove(enemy);
    }
}
