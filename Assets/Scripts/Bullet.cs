using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float bulletSpeed;
    public int bulletDamage;
    public float timeDuration;
	
	// Use this for initialization
	private void Start () 
	{
		Destroy(gameObject, timeDuration);
	}
	
	// Update is called once per frame
	private void Update () 
	{	
		MoveBullet();		
	}

	private void MoveBullet() 
	{		
		transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
	}

	
	
}
 