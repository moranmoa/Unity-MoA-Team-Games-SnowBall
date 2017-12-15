using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {

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
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical"));
		bool isJumping = CrossPlatformInputManager.GetButtonDown ("Jump");
		bool isFire = CrossPlatformInputManager.GetButtonDown ("Fire");
		isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

		if (Input.GetKey(left)||moveVec.x<0)
		{
			theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
		}else if (Input.GetKey(right)||moveVec.x>0)
		{
			theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
		}else
		{
			theRB.velocity = new Vector2(0, theRB.velocity.y);
		}
		if ((Input.GetKeyDown(jump)||isJumping) && isGrounded)
		{
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
		}
		if (Input.GetKeyDown(throwBall)||isFire){
			GameObject ballClone = (GameObject) Instantiate(snowBall,throwPoint.position,throwPoint.rotation);
			ballClone.transform.localScale = transform.localScale;
			anim.SetTrigger("Throw");

			throwSound.Play ();
		}

		if (theRB.velocity.x < 0) 
		{
			transform.localScale = new Vector3(-1,1,1);
		}
		else if(theRB.velocity.x > 0)
		{
			transform.localScale = new Vector3(1,1,1);
		}
		anim.SetFloat ("Speed", Mathf.Abs( theRB.velocity.x));
		anim.SetBool ("Grounded", isGrounded);


	}
}
