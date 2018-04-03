using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptPRed : MonoBehaviour {

    public static int scoreRValue = 0;
    Text scoreR;
    // Use this for initialization
    void Start()
    {

        scoreR = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        scoreR.text = "Score:" + scoreRValue;
    }
}
