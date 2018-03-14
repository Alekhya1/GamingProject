﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScipt : MonoBehaviour {
    public float speed;
    public Transform player;
  

	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up*speed); 
    }
    
}
