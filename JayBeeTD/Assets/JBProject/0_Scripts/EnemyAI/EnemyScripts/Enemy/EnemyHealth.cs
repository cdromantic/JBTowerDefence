using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    int premGive = 0;
    GoldCounter playerGold;
    public float enemyHealth;
    public float maxHealth = 10f;
    public float enemyDamage = 10f;
    EnemyWaveSpawn listRemoval;

    void Start() {
        playerGold = GameObject.FindGameObjectWithTag("GoldCounter").GetComponent<GoldCounter>();
        listRemoval = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<EnemyWaveSpawn>();
        maxHealth += (listRemoval.waveNum - 1) * 5;
        enemyHealth = maxHealth;
    }

    public void Damage(float damage) {
        enemyHealth -= damage;
        if (enemyHealth <= 0f) {
            if (Random.Range(1, 1000) == 1000) premGive = 1;
            playerGold.AddGold(2, premGive);
            listRemoval.RemoveEnemyFromList(gameObject);
            Destroy(gameObject);
        }
    }
}
