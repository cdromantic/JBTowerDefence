using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PremiumCurrencyCounter : MonoBehaviour
{
    [SerializeField]
    PremiumCurrencyCounter premCounterScripts;
    [SerializeField]
    TurretController tCont;

    public int premiumCurrency;
    Text premiumText;
    int currentPremCount;
    int oldPremCount;

    // Use this for initialization
    void Start()
    {
        premiumText = GetComponentInChildren<Text>();
        premiumCurrency = PlayerPrefs.GetInt("BeatCoin", 0);
        premiumText = GetComponentInChildren<Text>();
        if (tCont != null)
            tCont.ParsePremAmount(premiumCurrency);
        premiumText.text = PlayerPrefs.GetInt("BeatCoin", premiumCurrency).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(premiumCurrency);
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
        PlayerPrefs.SetInt("BeatCoin", 0);
        premiumText.text = "0";
        if (premCounterScripts != null)
            premCounterScripts.premiumText.text = "0";
    }

    public void AddPrem(int premAmount)
    {
        if (!(premAmount + premiumCurrency < 0) && premAmount < 0)
        {
            if (premCounterScripts != null)
                premCounterScripts.premiumCurrency += premAmount;
            premiumCurrency += premAmount;
        }
        else if (premAmount > 0)
        {
            if (premCounterScripts != null)
                premCounterScripts.premiumCurrency += premAmount;
            premiumCurrency += premAmount;

        }
    }
}


