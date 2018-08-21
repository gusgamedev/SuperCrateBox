using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 7.2f;

	public LayerMask layerGround;
	public Transform wallCheck;

	private Rigidbody2D rb2d;
	private SpriteRenderer sprite; 

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
	}

	private void Start() { 
		Destroy (gameObject, 8f);

		if (SetRandomFlip ())
			Flip ();
	
	}

	private void Update()
	{
		if (Physics2D.OverlapCircle (wallCheck.position, 0.1f, layerGround)) {
			Flip ();
		}
	}

	void FixedUpdate()
	{
		rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
	}

	void Flip()
	{		
		sprite.flipX = !sprite.flipX;
		speed = -speed;
		wallCheck.localPosition = new Vector2 (-wallCheck.localPosition.x, wallCheck.localPosition.y);
	}

	private bool SetRandomFlip() {
		//0 flip false, 1 flip true
		return Random.Range (0, 2) == 1;
	}

	private void OnTriggerEnter2D(Collider2D coll) {

		if (coll.CompareTag ("Fire")) {
			//do something
		}
	}
}
