using UnityEngine;
using TMPro;
using System;

public class UIHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public PlayerHealth PlayerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        PlayerHealth.OnhealthChanged += OnHealthChanged;
        PlayerHealth.OnHealthInitialised += OnHealthInit;
    }

    private void OnHealthInit(float newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    public void OnHealthChanged(float newHelth, float ammountChanged)
    {
        healthText.text = newHelth.ToString();
    }
   

}
