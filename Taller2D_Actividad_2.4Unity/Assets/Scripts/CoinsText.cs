using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsText : MonoBehaviour
{
    public TMP_Text coinsText;
    void Awake()
    {
        coinsText = GameObject.Find("CoinTMP").GetComponent<TMP_Text>();
    }

    public void ChangeCoinText(int monedas)
    {
        coinsText.text = "Coins: " + monedas;
    }
}
