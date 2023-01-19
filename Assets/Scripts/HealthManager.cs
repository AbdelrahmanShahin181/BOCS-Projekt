using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBarScript healthBar;
    [SerializeField] private SO_Position position;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentHealth = position.hp;
        healthBar.SetHealth(currentHealth);
    }

   
    void Update()
    {
        if(currentHealth <= 0) {
            SceneManager.LoadScene("Death");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
        position.hp = currentHealth;
    }

    public void heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        position.hp = currentHealth;
    }

}
