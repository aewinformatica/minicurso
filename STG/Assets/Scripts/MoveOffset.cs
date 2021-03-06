﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour {

	// Use this for initialization
	private Material currentMaterial;
	private float offset;
	public float speed;
	void Start () {

		currentMaterial = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		offset += speed * 0.001f;

		currentMaterial.SetTextureOffset("_MainTex",new Vector2(0,offset));
	}
}
