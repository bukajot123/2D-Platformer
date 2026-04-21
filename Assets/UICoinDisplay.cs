using UnityEngine;
using TMPro;
using System;

public class UICoinDisplay : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public PlayerCoin PlayerCoin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        PlayerCoin.OncoinChanged += OnCoinChanged;
        PlayerCoin.OncoinInitialised += OnCoinInit;
    }

    private void OnCoinInit(float newCoin)
    {
        CoinText.text = newCoin.ToString();
    }

    public void OnCoinChanged(float newCoin, float ammountChanged)
    {
        CoinText.text = newCoin.ToString();
    }


}
