using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Menu : MonoBehaviour {

	public string livel1Game;
	public string livel2Game;

	public void Startlivel1() {
		SceneManager.LoadScene (livel1Game);
	}
	public void Startlivel2()
	{
		SceneManager.LoadScene (livel2Game);
	}

	public void QuitGame () {
		Application.Quit();
	}

	//void Update () {
	//	bool isStart = CrossPlatformInputManager.GetButtonDown ("Start");
	//	bool isQuit = CrossPlatformInputManager.GetButtonDown ("Quit");
	//	if(isStart){
	//		StartGame ();
	//	}
	//	if(isQuit){
	//		QuitGame ();
	//	}
		
	//}
}
