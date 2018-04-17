using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public string h;
    public string v;
    public float speed;          
    private Rigidbody2D rb2d;      

    // Update is called once per frame
    void Update () {
		
	}

    // Use this for initialization
    void Start() {
        //Get and store a reference to the Rigidbody2D component so that it can be accessed.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate() {

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis(h);

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis(v);

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move the player.
        rb2d.AddForce(movement * speed);
    }
}
