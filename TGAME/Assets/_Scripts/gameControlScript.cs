using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControlScript : MonoBehaviour {
    GameObject blue;
    int valB = ApplicationsData.blueD;
    int valR = ApplicationsData.redD;
    int valG = ApplicationsData.greenD;
    // Use this for initialization
    void Start () {
		if(valB.Equals(1))
        {
            GameObject.Find("Player").SetActive(false);
        }
        else if (valR.Equals(1))
        {
            GameObject.Find("Player_Two").SetActive(false);
        }
        else if (valG.Equals(1))
        {
            GameObject.Find("Player_Three").SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
