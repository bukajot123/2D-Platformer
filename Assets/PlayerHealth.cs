using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    private bool canReciveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float helth, float ammountChanged);
    public event HealthChangedHandler OnhealthChanged;

    public void AddDamage(float damage)
    {
        if (canReciveDamage)
        {
            health -= damage;
            OnhealthChanged?.Invoke(health, -damage);
            canReciveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
        }
        Debug.Log(health);
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
   
    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        OnhealthChanged?.Invoke(health, healthToAdd);
        Debug.Log(health);
    }
}