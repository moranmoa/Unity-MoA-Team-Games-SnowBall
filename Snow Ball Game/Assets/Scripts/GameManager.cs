using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public int p1Life;
	public int p2Life;

	public GameObject gameOver;

	public GameObject[] p1Sticks;
	public GameObject[] p2Sticks;

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
		for (int i = 0; i < p1Sticks.Length; i++) {
			if (p1Life > i) {
				p1Sticks [i].SetActive (true);
			} else {
				p1Sticks [i].SetActive (false);
			}
		}
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
	}
}
