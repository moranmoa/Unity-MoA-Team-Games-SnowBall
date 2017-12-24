using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SnowBall : NetworkBehaviour {
	
	public float ballSpeed;

	public GameObject snowBallEffect;

	private Rigidbody2D theRB;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	[ServerCallback]
	void Update () {

		theRB.velocity = new Vector2 (ballSpeed * transform.localScale.x, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		CmdsnowBallEffect ();
		NetworkServer.Destroy(gameObject);

		//if (!isServer)
			//return;
		if (other.gameObject.tag != "Player1")
			return;
		PlayetHealth health = other.gameObject.GetComponent<PlayetHealth> ();
		if (health != null)
			health.TakeDamage (1);
		//Network.Destroy(snowBallEffect1);
		/*
		if (other.tag == "Player1 Network") {
			FindObjectOfType<GameManager> ().HurtP1 ();
		}
		if (other.tag == "Player2 Network") {
			FindObjectOfType<GameManager> ().HurtP2 ();
		}
		*/
	}
	[Command]
	void CmdsnowBallEffect()
	{
		//GameObject ballClone = Instantiate(snowBall,throwPoint.position,throwPoint.rotation) as GameObject;
		//ballClone.transform.localScale = transform.localScale;
		//NetworkServer.Spawn (ballClone);
		GameObject snowBallEffect1 = Instantiate (snowBallEffect, transform.position, transform.rotation);
		NetworkServer.Spawn (snowBallEffect1);
	}

}
