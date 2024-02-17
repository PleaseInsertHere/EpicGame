using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float Spd;

    Rigidbody2D rb;
    private bool faceLeft = false;
    Vector2 Dir = Vector2.zero;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && faceLeft)
        {
            Flip();
            faceLeft = false;
        }
        if (Input.GetAxisRaw("Horizontal") < 0 && !faceLeft)
        {
            Flip();
            faceLeft = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Dir.x = Input.GetAxisRaw("Horizontal");
        Dir.y = Input.GetAxisRaw("Vertical");

        rb.velocity = Spd * Dir;
    }
            void Flip()
            {
                var theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        
    
}
