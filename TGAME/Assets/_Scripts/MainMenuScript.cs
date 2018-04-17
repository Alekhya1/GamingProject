using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	public void PlayGame()
    {
        ApplicationsData.singP = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
    public void PlayGame2()
    {
        ApplicationsData.twoP = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayGame3()
    {
        ApplicationsData.threeP = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayGame4()
    {
        ApplicationsData.fourP = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
	
}
