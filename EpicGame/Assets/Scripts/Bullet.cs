using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject bullet;

   // [Range(1, 10)]
   // [SerializeField] private float lifetime = 3f;

    public int damage = 10; // Damage inflicted by this bullet

    private Rigidbody2D rb; // Declare Rigidbody2D field

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Assign the Rigidbody2D component
    //    Destroy(gameObject /*, lifetime*/);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed; // Fix the spelling of velocity
    }

    private void OnCollisionStay2D (Collision2D other)
    {
        Destroy(bullet);
    }
}
