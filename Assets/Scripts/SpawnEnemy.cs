using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    
    public GameObject[] enemies;
  
    private float spawnTime = 1f;   
    
	void Start () {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Spawn () {

        int index = Random.Range (0, enemies.Length);
		Instantiate (enemies[index], transform.position, Quaternion.identity);        
    }

}
