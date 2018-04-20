using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float enemyHealth;
    public float maxHealth = 10f;
    public float enemyDamage = 10f;
    EnemyWaveSpawn listRemoval;
    // Use this for initialization
    void Start() {
        listRemoval = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<EnemyWaveSpawn>();
        maxHealth += (listRemoval.waveNum - 1) * 5;
        enemyHealth = maxHealth;
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
