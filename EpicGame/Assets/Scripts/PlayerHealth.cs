using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float currentHealth = 0f;
    [SerializeField] private float maxHealth = 10f;

    private void Start()
    {
        currentHealth = maxHealth;
    }
   
    public void UpdateHealth(float mod)
    {
        currentHealth += mod;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if(currentHealth <= 0f)
        {
            currentHealth = 0f;
            Debug.Log("Potato died");
        }
    }
   /*
   
   
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
    */
}
