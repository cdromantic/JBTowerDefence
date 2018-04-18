using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float enemyHealth;
    public float maxHealth = 10f;
    public float enemyDamade = 10f;
    EnemyWaveSpawn listRemoval;
    // Use this for initialization
    void Start() {
        enemyHealth = maxHealth;
        listRemoval = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<EnemyWaveSpawn>();
    }

    // Update is called once per frame
    void Update() {

    }
    public void Damage(float damage) {
        enemyHealth -= damage;
        if (enemyHealth <= 0f) {
            listRemoval.RemoveEnemyFromList(gameObject);
            Destroy(gameObject);
        }
    }
}
