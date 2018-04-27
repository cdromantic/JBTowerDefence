using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour {
    [SerializeField]
    PremiumCurrencyCounter myPremiumCurrency;
    public Image[] lives;
    JayBeeHealth jBHP;
    int jayBeeLives;

	void Start () {
        jBHP = GameObject.FindGameObjectWithTag("Player").GetComponent<JayBeeHealth>();
	}

    void Update() {
        jayBeeLives = (int)jBHP.jBHealth;
        for(int i = 0; i < lives.Length; i++) {
            if (jayBeeLives - i <= 0) {
                lives[i].enabled = false;
            }
            else { lives[i].enabled = true; }
        }
    }
    public void AddHealth(int amountExtra) {
        if (myPremiumCurrency.premiumCurrency >= 25) {
            jBHP.jBHealth += amountExtra;
            myPremiumCurrency.AddPrem(-25);
        }
    }
}
