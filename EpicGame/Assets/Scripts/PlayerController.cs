using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public LayerMask enemyLayers;
    public GameObject[] swords; // Array of sword GameObjects
    public int[] swordDamages; // Array of sword damages

    private bool isAttacking = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            isAttacking = true;
            Attack();
        }
    }

    void Attack()
    {
        // Play attack animation or sound if needed

        // Loop through each sword
        for (int i = 0; i < swords.Length; i++)
        {
            GameObject sword = swords[i];
            int damage = swordDamages[i];

            // Detect enemies hit by current sword
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(sword.transform.position, sword.GetComponent<BoxCollider2D>().size, 0, enemyLayers);
            DamageEnemies(hitEnemies, damage);
        }

        // Set cooldown or animation delay
        Invoke("ResetAttack", 0.5f);
    }

    void ResetAttack()
    {
        isAttacking = false;
    }

    void DamageEnemies(Collider2D[] enemies, int damage)
    {
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
    }
}
