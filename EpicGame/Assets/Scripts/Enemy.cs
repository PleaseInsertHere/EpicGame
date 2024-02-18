using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public int touchDamage = 10;

    void Start()
    {
        currentHealth = maxHealth;
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

    void Die()
    {
        // Death animation or sound, or any other death logic
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(touchDamage);
        }
    }
}
