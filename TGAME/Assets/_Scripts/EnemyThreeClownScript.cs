﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeClownScript : MonoBehaviour {

    public GameObject blood;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("Bullet"))
        {
            ScoreScriptGreen.scoreGValue += 1;
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
