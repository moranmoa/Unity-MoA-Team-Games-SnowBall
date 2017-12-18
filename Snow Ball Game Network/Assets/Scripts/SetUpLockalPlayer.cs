using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetUpLockalPlayer : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if (isLocalPlayer)
			GetComponent<PlayerController> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
