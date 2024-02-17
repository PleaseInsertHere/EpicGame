using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public Animator anim;
    
    [SerializeField] HealthBar healthBar;

    void awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0) ;
        {
            anim.SetBool("IsDead", true);
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
