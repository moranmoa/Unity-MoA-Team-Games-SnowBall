using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DestroyOverTime : NetworkBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime < 0) {
			//if (!isServer)
				//return;
			NetworkServer.Destroy (gameObject);
		}
	}
}
