using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBlueDalekHealthScript : MonoBehaviour {

    Vector3 localScale1;
    // Use this for initialization
    void Start()
    {
        localScale1 = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale1.x = finalblueDalekScript.healthAmount;
        transform.localScale = localScale1;

    }
}

