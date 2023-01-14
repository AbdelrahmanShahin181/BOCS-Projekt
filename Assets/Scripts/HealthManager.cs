using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBarScript healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

   
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public void heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
