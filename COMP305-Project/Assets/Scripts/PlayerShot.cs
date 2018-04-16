using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {

    public bool isFiring;
    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetewwnShots;
    private float shotCounter;
    public Transform firePoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)){
            transform.position += transform.right * Time.deltaTime * 5;
            isFiring = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            isFiring = false;
        }


        if (isFiring){
            shotCounter -= Time.deltaTime;
            if(shotCounter<= 0){
                shotCounter = timeBetewwnShots;
                BulletController newBullet =  Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
        }
        else{
            shotCounter = 0;
        }
	}
}
