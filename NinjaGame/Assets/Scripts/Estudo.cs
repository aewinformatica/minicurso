using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estudo : MonoBehaviour {

	private Animator playerAnimator;
	private Rigidbody2D playerRigidBody;
	public Sprite novoSprite;

	public float horizontal;
	public float velocidade,velocidadeBase,adicionalVelocidade,forcaPulo;
	private bool walk;
	// Use this for initialization
	void Start () {

		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		velocidade = velocidadeBase;
	}
	
	// Update is called once per frame
	void Update () {

		horizontal = Input.GetAxis ("Horizontal");

		if (horizontal != 0) {walk = true;	} else {walk = false;}

		if (Input.GetButtonDown ("Correr")) {
			
			velocidade = velocidadeBase + adicionalVelocidade;
		}

		if (Input.GetButtonUp ("Correr")) {

			velocidade = velocidadeBase ;
		}

		if (Input.GetButtonDown ("Jump")) {

			playerRigidBody.AddForce (new Vector2 (0, forcaPulo));
		}

		playerAnimator.SetBool ("walkAnimator", walk);

	}
	void FixedUpdate(){
		playerRigidBody.velocity = new Vector2 (horizontal * velocidade, playerRigidBody.velocity.y);

	}
}
