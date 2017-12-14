﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour {
	
	public float ballSpeed;

	public GameObject snowBallEffect;

	private Rigidbody2D theRB;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		theRB.velocity = new Vector2 (ballSpeed * transform.localScale.x, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Instantiate (snowBallEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}