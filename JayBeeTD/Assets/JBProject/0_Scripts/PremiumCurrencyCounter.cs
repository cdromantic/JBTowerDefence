using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PremiumCurrencyCounter : MonoBehaviour
{
    [SerializeField]
    TurretController tCont;

    public int premiumCurrency;
    public Text premiumText;
    int currentPremCount;
    int oldPremCount;

    // Use this for initialization
    void Start()
    {
        premiumCurrency = PlayerPrefs.GetInt("BeatCoin", 0);
        premiumText = GetComponentInChildren<Text>();
        if (tCont != null)
        tCont.ParsePremAmount(premiumCurrency);
        premiumText.text = PlayerPrefs.GetInt("BeatCoin", premiumCurrency).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentPremCount = premiumCurrency;
        //premiumText.text = premiumCurrency.ToString();

        if (currentPremCount != oldPremCount)
        {
            premiumText.text = premiumCurrency.ToString();
            oldPremCount = currentPremCount;
            PlayerPrefs.SetInt("BeatCoin", currentPremCount);
            if (tCont != null)
            tCont.ParsePremAmount(premiumCurrency);
        }
    }

    public void Reset()
    {
            PlayerPrefs.DeleteKey("BeatCoin");
            premiumText.text = "0";
    }

    public void AddPrem(int premAmount)
    {
        premiumCurrency += premAmount;
    }
}


