using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform spawnPosition;
	public GameObject bullet;
	public float fireRate;

	private bool canShoot = true;

	// Use this for initialization
	private void Start () 
	{
		VerifyObjects();			
	}
	
	// Update is called once per frame
	private void Update () 
	{	
		if (Input.GetButtonDown("Fire1")) {
			if (canShoot)
			{
				DisableShooting();
				SpawnBulelt();				
				Invoke("EnableShooting", fireRate);
			}
		}		
	}

	private void SpawnBulelt() 
	{		
		Instantiate(bullet, spawnPosition.position, Quaternion.identity);
	}

	private void EnableShooting() 
	{
		canShoot = true;
	}

	private void DisableShooting()
	{
		canShoot = false;
	}

	private void VerifyObjects() 
	{
		if (bullet == null)
			Debug.Log("Set bullet object in inspector"); 			 

		if (spawnPosition == null)
			Debug.Log("Set spawnPosition object in inspector"); 
	}
}
