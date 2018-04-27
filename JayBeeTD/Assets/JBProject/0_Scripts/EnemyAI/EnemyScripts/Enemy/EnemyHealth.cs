using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    int premGive;
    GoldCounter playerGold;
    PremiumCurrencyCounter playerPrem;
    public float enemyHealth;
    public float maxHealth = 10f;
    public float enemyDamage = 10f;
    EnemyWaveSpawn listRemoval;

    void Start() {
        playerGold = GameObject.FindGameObjectWithTag("GoldCounter").GetComponent<GoldCounter>();
        playerPrem = GameObject.FindGameObjectWithTag("PremCounter").GetComponent<PremiumCurrencyCounter>();
        listRemoval = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<EnemyWaveSpawn>();
        maxHealth += (listRemoval.waveNum - 1) * 5;
        enemyHealth = maxHealth;
        premGive = Random.Range(1, 5);
    }

    public void Damage(float damage) {
        enemyHealth -= damage;
        if (enemyHealth <= 0f) {
            //if (Random.Range(1, 200) == 200) premGive = 1;
            //{
                playerPrem.AddPrem(premGive);
            //}
            playerGold.AddGold(2);
            listRemoval.RemoveEnemyFromList(gameObject);
            Destroy(gameObject);
        }
    }
}
