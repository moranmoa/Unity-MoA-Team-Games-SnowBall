using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class PlayerControllerNet : NetworkBehaviour {
	[SyncVar]
	public Vector3 scale;

	public float moveSpeed;
	public float jumpForce;

	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode throwBall;

	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;


	private Rigidbody2D theRB;

	private Animator anim;

	public GameObject snowBall;
	public Transform throwPoint;

	public AudioSource throwSound;

	// Use this for initialization
	void Start () {

		theRB = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		scale = new Vector3 (1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 moveVec;//= new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical"));
		bool isJumping; //= CrossPlatformInputManager.GetButtonDown ("Jump");
		bool isFire ;//= CrossPlatformInputManager.GetButtonDown ("Fire");
		isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);


		if (isLocalPlayer) {
			if (Input.GetKey (left)) {//||moveVec.x<0)
				theRB.velocity = new Vector2 (-moveSpeed, theRB.velocity.y);
				scale = new Vector3 (-1, 1, 1);
			//	theRB.transform.localScale = scale;
				Cmdscale(scale);
			} else if (Input.GetKey (right)) {//||moveVec.x>0)
				theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);
				scale = new Vector3 (1, 1, 1);
				//theRB.transform.localScale = scale;//CmdflipScale ();
				Cmdscale(scale);
			} else {
				theRB.velocity = new Vector2 (0, theRB.velocity.y);
			}
			if ((Input.GetKeyDown (jump)) && isGrounded) {//||isJumping
				theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
			}
			if (Input.GetKeyDown (throwBall)) {//||isFire)
				//GameObject ballClone = (GameObject) 
				/*if (theRB.velocity.x < 0) 
				{
					scale = new Vector3(-1,1,1);
				}
				else if(theRB.velocity.x > 0)
				{
					scale = new Vector3(1,1,1);
				}*/
				CmdSnowBall (scale);
				//Network.Instantiate(snowBall,throwPoint.position,throwPoint.rotation,0);
				//ballClone.transform.localScale = transform.localScale;
					anim.SetTrigger ("Throw");
				//throwSound.Play ();
			}
		}
		/*
		if (isLocalPlayer){
			if (theRB.velocity.x < 0) 
			{
				scale = new Vector3(-1,1,1);
				theRB.transform.localScale = scale;
				//CmdflipScale ();
			}
			else if(theRB.velocity.x > 0)
			{
				scale = new Vector3(1,1,1);
				theRB.transform.localScale = scale;//CmdflipScale ();
			}
		}
		*/
		if (isLocalPlayer)
		anim.SetFloat ("Speed", Mathf.Abs( theRB.velocity.x));
		if (isLocalPlayer)
		anim.SetBool ("Grounded", isGrounded);


	}
	[Command]
	void CmdSnowBall(Vector3 scale)
	{
		GameObject ballClone = Instantiate(snowBall,throwPoint.position,throwPoint.rotation) as GameObject;

		NetworkServer.Spawn (ballClone);
		Rpcballscale (scale, ballClone);
	}
	[ClientRpc]
	void Rpcballscale(Vector3 scale,GameObject ballClone)
	{
		//if (isLocalPlayer)
		//	return;
		ballClone.transform.localScale = scale;;
	}

	[Command]
	void CmdflipScale()
	{
			transform.localScale = scale;
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
		theRB.transform.localScale=scale;
	}

}
