using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public int p1Life;
	public int p2Life;

	public GameObject gameOver;
	public GameObject canvas2gameoverreload;
	public GameObject[] p1Sticks;
	public GameObject[] p2Sticks;

	public AudioSource hurtSound;

	public string mainManu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (p1Life <= 0) {
			player1.SetActive (false);
			gameOver.SetActive (true);
			canvas2gameoverreload.SetActive (true);
		}

		if (p2Life <= 0) {
			player2.SetActive (false);
			gameOver.SetActive (true);
			canvas2gameoverreload.SetActive (true);
			//gameOver.GetComponent<image>
		}
		//bool isReload = CrossPlatformInputManager.GetButtonDown ("Reload");
		if( Input.GetKeyDown(KeyCode.R)){
			Reload ();//SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
		if( Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene (mainManu);
		}



	}

	public void HurtP1(){
		p1Life -= 1;
		for (int i = 0; i < p1Sticks.Length; i++) {
			if (p1Life > i) {
				p1Sticks [i].SetActive (true);
			} else {
				p1Sticks [i].SetActive (false);
			}
		}

		hurtSound.Play ();
	}

	public void HurtP2(){
		p2Life -= 1;
		for (int i = 0; i < p2Sticks.Length; i++) {
			if (p2Life > i) {
				p2Sticks [i].SetActive (true);
			} else {
				p2Sticks [i].SetActive (false);
			}
		}
		hurtSound.Play ();
	}
	public void Reload(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
