using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int currentHealth = 3;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            //Player Dies
        }
    }

    public void HealDamage(int amt)
    {
        currentHealth += amt;
        if(currentHealth > maxHealth) { currentHealth = maxHealth; }
    }
}
