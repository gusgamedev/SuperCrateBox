using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 6f;
    public float jumpForce = 11f;
    
    public LayerMask layerGround;
    
    private bool grounded = false;
    private bool jumping = false;

    private Rigidbody2D rb2d;
	private SpriteRenderer sprite; 
	float move = 0;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		move = Input.GetAxisRaw("Horizontal");
		Flip (move);

        grounded = Physics2D.OverlapCircle(transform.position, 0.2f, layerGround);
    
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
        }
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (jumping)
        {
			rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumping = false;
        }
    }

	void Flip(float move)
    {
		if ((move > 0f && !sprite.flipX) || (move < 0f && !sprite.flipX)) 
		{
			sprite.flipX = !sprite.flipX;
		}
        
    }
}
