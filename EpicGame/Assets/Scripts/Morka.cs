using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morka : MonoBehaviour
{
    private float morkosSpeed =  6f;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        morkosSpeed = lastVelocity.magnitude;
        Vector2 direction = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(morkosSpeed, 0f);
    }
}
