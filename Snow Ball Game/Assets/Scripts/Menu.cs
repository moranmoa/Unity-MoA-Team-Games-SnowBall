using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Menu : MonoBehaviour {

	public string mainGameScene;
	public void StartGame () {
		SceneManager.LoadScene (mainGameScene);
	}

	void QuitGame () {
		Application.Quit();
	}

	void Update () {
		bool isStart = CrossPlatformInputManager.GetButtonDown ("Start");
		bool isQuit = CrossPlatformInputManager.GetButtonDown ("Quit");
		if(isStart){
			StartGame ();
		}
		if(isQuit){
			QuitGame ();
		}
		
	}
}
