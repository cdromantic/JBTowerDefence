using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JayBeeHealth : MonoBehaviour {
    [SerializeField]
    private Canvas gameOver;
    [SerializeField]
    private AudioSource gameOverTheme;
    [SerializeField]
    private AudioSource bgm;

    public float jBHealth = 5f;
    public float jBMaxHealth = 5f;

    public bool jBIsDead;
    void Start() {
        jBHealth = jBMaxHealth;
        Time.timeScale = 1f;
        gameOver.enabled = false;
    }

    void Update() {

    }
    public void Damage() {
        jBHealth -= 1f;
        if (jBHealth < 1f) {
            jBIsDead = true;
            if (jBIsDead) {
                Time.timeScale = 0f;
                gameOver.enabled = true;
                bgm.GetComponent<AudioSource>().Pause();
                gameOverTheme.GetComponent<AudioSource>().Play();
            }
        }
    }
}