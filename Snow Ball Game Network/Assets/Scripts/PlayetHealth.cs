using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayetHealth : NetworkBehaviour {

	public int maxHealth;
	Text informationText;
	public int health;
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int amount)
	{
		if ( health <= 0) //!isServer ||
			return;
		health -= amount;
		if (health <= 0) {
			health = 0;
			RpcDied ();
			Invoke ("BackToLobby", 3f);
			return;
		}
	}
		[ClientRpc]
		void RpcDied()
		{
		informationText = GameObject.FindObjectOfType<Text> ();
		if (isLocalPlayer)
			informationText.text = "Game Over";
		else
			informationText.text = "You Won!";
		}
	void BackToLobby()
	{
		FindObjectOfType<NetworkLobbyManager> ().ServerReturnToLobby ();
	}

}
