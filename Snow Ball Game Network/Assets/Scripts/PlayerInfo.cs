using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInfo : NetworkBehaviour {
	[SyncVar]
	public Color color;
	[SyncVar]
	public string name;
	Rigidbody2D theRB;
	Vector3 scale;
	TextMesh thetext;

	//public GameObject pname;
	MeshRenderer rends;
	// Use this for initialization
	void Start () {
		rends = GetComponentInChildren<MeshRenderer> ();
		//for (int i = 0; i < rends.Length; i++)
			rends.material.color = color;
		thetext = GetComponentInChildren<TextMesh>();
		thetext.text = name;
		theRB = GetComponent<Rigidbody2D>();
		scale = new Vector3(0.5f,0.5f,0.5f);
		Cmdscale (scale);
	}
	
	// Update is called once per frame
	void Update () {
		if (theRB.velocity.x < 0) 
				{
			scale = new Vector3(-0.5f,0.5f,0.5f);
					Cmdscale (scale);
				}
				else if(theRB.velocity.x > 0)
				{
			scale = new Vector3(0.5f,0.5f,0.5f);
					Cmdscale (scale);
				}
	}
	[Command]
	void Cmdscale(Vector3 scale)
	{
		Rpcscale(scale);
	}

	[ClientRpc]
	void Rpcscale(Vector3 scale)
	{
		//if (isLocalPlayer)
		//	return;
		thetext.transform.localScale=scale;
	}
}
