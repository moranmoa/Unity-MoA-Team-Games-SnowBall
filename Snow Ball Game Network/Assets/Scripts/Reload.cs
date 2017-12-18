using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Reload : MonoBehaviour {


	public void Reloads(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}



//	void Update () {
//		bool isStart = CrossPlatformInputManager.GetButtonDown ("Start");
//		bool isQuit = CrossPlatformInputManager.GetButtonDown ("Quit");
//		if(isStart){
//			StartGame ();
//		}
//		if(isQuit){
//			QuitGame ();
//		}
//	}

