using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//private bool WhatIsGrounded = true; // is player on the ground?

	private Animator playerAnimator;
	private Rigidbody2D playerRigidBody;

	public float horizontal;
	public float vertical;
	public float velocidade,velocidadeBase,adicionalVelocidade,forcaPulo;

	//some flags to check when certain animations are playing
	bool crouch = false;
	bool walk = false;
	//bool hadooken = false;
	bool jump = false;

	void Start()
	{
		//define the animator attached to the player
		playerAnimator = this.GetComponent<Animator>();
		playerRigidBody = this.GetComponent<Rigidbody2D>();
		velocidade = velocidadeBase;
	}

	void Update(){

		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		if (horizontal != 0) {walk = true;	} else {walk = false;}

		if (vertical != 0) {crouch = true;	walk = false; } else {crouch = false;}

		if (Input.GetButtonDown ("Correr")) {

			velocidade = velocidadeBase + adicionalVelocidade;
		}

		if (Input.GetButtonUp ("Correr")) {

			velocidade = velocidadeBase ;
		}

		if (Input.GetButtonDown ("Jump")) {

			jump = true;

			playerRigidBody.AddForce (new Vector2 (0, forcaPulo));

		} else if (Input.GetButtonUp ("Jump")) {
		
			jump = false;
		}

		playerAnimator.SetBool ("walkAnimator", walk);
		playerAnimator.SetBool ("jumpAnimator", jump);
		playerAnimator.SetBool ("crouchAnimator", crouch);

	}
		
	void FixedUpdate()
	{
		

		playerRigidBody.velocity = new Vector2 (horizontal * velocidade, playerRigidBody.velocity.y);
	}
		
}