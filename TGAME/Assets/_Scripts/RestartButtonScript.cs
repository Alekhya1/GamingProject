using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(ApplicationsData.blueD.ToString());
	}
    public void RestartScene()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartSceneGameOver()
    {
        ApplicationsData.singP = 0;
        ScoreScriptBlue.scoreValue = 0;
        SceneManager.LoadScene(0);
        
    }
    public void StartFinalScene()
    {
        Debug.Log("Test");
        SceneManager.LoadScene("Level3");

    }

    public void TestGoTonEXT()
    {
        SceneManager.LoadScene("Level3");
    }

}
