using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject[] swords; // Array of sword GameObjects
    public int[] swordDamages; // Array of sword damages

    private bool isAttacking = true; // Changed to always attack

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        healthSlider.value = (float)currentHealth / maxHealth; // Update the value based on currentHealth
    }
    

    void Update()
    {
        if (isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        // Loop through each sword
        for (int i = 0; i < swords.Length; i++)
        {
            GameObject sword = swords[i];
            int damage = swordDamages[i];

            // Check collisions with enemies
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(sword.transform.position, sword.GetComponent<BoxCollider2D>().size, 0);
            DamageEnemies(hitEnemies, damage);

            // Debug if enemies are in contact with the sword
            if (hitEnemies.Length > 0)
            {
                //Debug.Log("Sword " + i + " is in contact with an enemy!");
            }
        }
    }

    void DamageEnemies(Collider2D[] enemies, int damage)
    {
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyEnemy>().TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
         currentHealth -= damage;
         Debug.Log(currentHealth);
         Debug.Log(damage);
         currentHealth = Mathf.Max(currentHealth, 0);
         UpdateHealthBar(); // Update the health bar after taking damage

        // Check if player dies
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Game over logic, like showing a game over screen, resetting level, etc.
        Debug.Log("Player died!");
        gameObject.SetActive(false); // For example, deactivate the player game object.
    
}
private void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Bullet"))
    {
        // Access the collider component of the bullet object
        Collider2D bulletCollider = other.collider;

        // Get the damage value from the bullet's collider object
        Bullet bullet = bulletCollider.GetComponent<Bullet>();
        if (bullet != null)
        {
            TakeDamage(bullet.damage);
        }
    }
}
}


