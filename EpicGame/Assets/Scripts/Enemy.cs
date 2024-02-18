using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public int touchDamage = 10;

    [SerializeField] private EnemyHealthBar healthBar;

    private void Awake()
    {
        // Ensure that EnemyHealthBar component is assigned
        if (healthBar == null)
        {
            Debug.LogError("EnemyHealthBar is not assigned to the Enemy script.", this);
            return;
        }

        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        Debug.Log("Enemy takes " + damage + " damage.");

        // Check if enemy dies
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Death animation or sound, or any other death logic
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(touchDamage);
            }
            else
            {
                Debug.LogWarning("PlayerController component is missing on the player GameObject.", collision.gameObject);
            }
        }
    }
}
