using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
    public GameObject EnemyBulletGO,BulletR,BulletL;
    Vector2 bulletPos,bulletPos1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //fire();
        Destroy(gameObject, 3f);
	}
    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Player");
    }
  // void FireEnemy
}
