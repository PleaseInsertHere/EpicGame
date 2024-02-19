using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyEnemy : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public int touchDamage = 10;
    private bool canTakeDamage = true;
    private float damageCooldown = 1f;

    public GameObject healthBarPrefab; // Reference to the health bar prefab
    private GameObject healthBarInstance; // Instance of the health bar
    private Text healthBarText; // Text component of the health bar

    private void Awake()
    {
        currentHealth = maxHealth; // Set currentHealth after healthBar is initialized
        CreateHealthBar();
    }

    private void CreateHealthBar()
    {
        // Instantiate the health bar prefab
        healthBarInstance = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        // Set the parent of the health bar to be the canvas
        healthBarInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
        // Get the text component of the health
        healthBarText = healthBarInstance.GetComponentInChildren<Text>();
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        // Update the text of the health bar to display current health
        healthBarText.text = "Health: " + currentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;

            Debug.Log("Enemy takes " + damage + " damage.");

            // Check if enemy dies
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(DamageCooldown());
                UpdateHealthBar();
            }
        }
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }

    private void Die()
    {
        // Death animation or sound, or any other death logic
        Destroy(gameObject);
        // Destroy the health bar when the enemy dies
        Destroy(healthBarInstance);
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