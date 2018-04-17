using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMainbgController : MonoBehaviour {

    GameObject blue;
    int valP1 = ApplicationsData.singP;
    int valP2 = ApplicationsData.twoP;
    int valP3 = ApplicationsData.threeP;
    int valP4 = ApplicationsData.fourP;
    // Use this for initialization
    void Start()
    {
        if (valP1.Equals(1))
        {
            //GameObject.Find("Player").SetActive(false);
            GameObject.Find("Player_Two").SetActive(false);
            GameObject.Find("Player_Three").SetActive(false);
            GameObject.Find("Player_Four").SetActive(false);
            GameObject.Find("EnemySpawnerRed").SetActive(false);
            GameObject.Find("EnemySpawnerGreen").SetActive(false);
           
        }
        else if (valP2.Equals(1))
        {
            GameObject.Find("Player_Three").SetActive(false);
            //GameObject.Find("Player_Two").SetActive(false);
            GameObject.Find("Player_Four").SetActive(false);
            GameObject.Find("EnemySpawnerGreen").SetActive(false);

            //  GameObject.Find("Player_Three").SetActive(false);
        }
        else if (valP3.Equals(1))
        {
            GameObject.Find("Player_Four").SetActive(false);

            // GameObject.Find("Player_Three").SetActive(false);
        }

    }
    // Update is called once per frame
    void Update () {
		
	}
}
