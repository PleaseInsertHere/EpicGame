using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public int touchDamage = 10;

    private void Awake()
    {

        currentHealth = maxHealth; // Set currentHealth after healthBar is initialized

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Enemy takes " + damage + " damage.");

        // Check if enemy dies
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Death animation or sound, or any other death logic
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
