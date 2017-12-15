using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public int p1Life;
	public int p2Life;

	public GameObject gameOver;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (p1Life <= 0) {
			player1.SetActive (false);
			gameOver.SetActive (true);
		}

		if (p2Life <= 0) {
			player2.SetActive (false);
			gameOver.SetActive (true);
			//gameOver.GetComponent<image>
		}
	}

	public void HurtP1(){
		p1Life -= 1;
	}

	public void HurtP2(){
		p2Life -= 1;
	}
}
