using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    private bool canReciveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float newHelth, float ammountChanged);
    public event HealthChangedHandler OnhealthChanged;

    public delegate void OnHealthInitialisedHandler(float newHealth);
    public event OnHealthInitialisedHandler OnHealthInitialised;    

    public void AddDamage(float damage)
    {
        if (canReciveDamage)
        {
            health -= damage;
            OnhealthChanged?.Invoke(health, -damage);
            canReciveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
        }
        
        if(health <= 0)
        {
            SceneManager.LoadScene("GameFail");
        }
    }

    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        canReciveDamage = true;
    }

    void Start()
    {
        health = maxHealth;
        OnHealthInitialised?.Invoke(health);
    }

    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        OnhealthChanged?.Invoke(health, healthToAdd);
        Debug.Log(health);
    }
}