using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator Anime;
    public Rigidbody2D playerRigidbody;
    public int forceJump;


    public bool slide;

    //verifica o chao
    public Transform GroundCheck;
    public bool grounded;
    public LayerMask WhatIsGround;

    //slide
    public float slideTemp;
    public Transform colisor;
    public float timeTemp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")&& grounded == true)
        {
            playerRigidbody.AddForce(new Vector2(0, forceJump));
            if (slide == true)
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
            }
            slide = false;
        }
        if (Input.GetButtonDown("Slide")&& grounded == true && slide == false)
        {
            colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
            slide = true;
            timeTemp = 0;
        }

        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, WhatIsGround);

        if (slide == true)
        {
            timeTemp += Time.deltaTime;
            if (timeTemp >= slideTemp)
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
                slide = false;
            }
        }
        Anime.SetBool("jump", !grounded);
        Anime.SetBool("slide", slide);
		
	}

    private void OnTriggerEnter2D()
    {
        Debug.Log("Bateu");
    }
}
