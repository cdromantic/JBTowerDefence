using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour {
    //[SerializeField]
    //scriptthatyouwillwriteJordan JordansScriptForPremiumCurrency;
    int premiumCurrency;
    [SerializeField]
    TurretController tCont;
    public int goldCount;
    int currentGoldCount;
    int oldGoldCount;
    int currentPremCount;
    int oldPremCount;
    Text goldText;

    void Start() {

        //premiumCurrency = JordansScriptForPremiumCurrency.premiumAmount; - this is so we know the premium amount at the start
        goldCount = 15;
        goldText = GetComponentInChildren<Text>();
        tCont.ParseGoldAmount(goldCount);
        goldText.text = goldCount.ToString();
    }

    void Update() {
        currentGoldCount = goldCount;
        if (currentGoldCount != oldGoldCount) {
            goldText.text = goldCount.ToString();
            oldGoldCount = currentGoldCount;
            tCont.ParseGoldAmount(goldCount);
        }
        if(currentPremCount != oldPremCount) {
            oldPremCount = currentPremCount;
            //JordansScriptForPremiumCurrency.SendPremAmt(premiumCurrency);
        }
    }
    public void AddGold(int goldAmount, int premCurr) {
        goldCount += goldAmount;
        premiumCurrency += premCurr;
        currentPremCount = premiumCurrency;
    }
}

/*HERE IS HOW TO DO THE SENDING THING
 * make reference in this script:
 * [SerializeField]
 * scriptthatyouwillwriteJordan JordansScriptForPremiumCurrency;
 * 
 * then put the script into the serialized field on the gold canvas item
 * 
 * then, in scriptthatyouwillwriteJordan, include:
 * 
 * public void SendPremAmt(int premCurr){
 * put the local "highscore" script here, where "premCurr" is the premium currency;
 * }
 */