using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerScript : MonoBehaviour {
    public GameObject enemy;
    public Transform player;
    float randX, randY;
    Vector2 whereToSpawn;
    public float spawnrate = 2f;
    float nextSpawn = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Time.time>nextSpawn)
        {
            nextSpawn = Time.time + spawnrate;
            randX = Random.Range(-2.95f, 1.45f);
            randY = Random.Range(-4.0f, 4.0f);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity); 
        }
		
	}
    
}
