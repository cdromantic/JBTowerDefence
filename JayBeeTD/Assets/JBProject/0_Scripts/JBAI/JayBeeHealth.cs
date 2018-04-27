using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JayBeeHealth : MonoBehaviour {

    public float jBHealth = 5f;
    public float jBMaxHealth = 5f;

    public bool jBIsDead;
    void Start() {
        jBHealth = jBMaxHealth;
    }

    void Update() {

    }
    public void Damage() {
        jBHealth -= 1f;
        if (jBHealth < 1f) {
            jBIsDead = true;
            if (jBIsDead) {
                //endgamescript
                Destroy(gameObject);
            }
        }
    }
}