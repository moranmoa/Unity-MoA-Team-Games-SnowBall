using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInfo : NetworkBehaviour {
	[SyncVar]
	public Color color;
	[SyncVar]
	public string name;
	//public GameObject pname;
	MeshRenderer rends;
	// Use this for initialization
	void Start () {
		rends = GetComponentInChildren<MeshRenderer> ();
		//for (int i = 0; i < rends.Length; i++)
			rends .material.color = color;
		GetComponentInChildren<TextMesh>().text = name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
