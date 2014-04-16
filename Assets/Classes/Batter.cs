﻿using UnityEngine;
using System.Collections;

public class Batter : MonoBehaviour {

	private bool swinging;

	private Vector3 startingPosition;

	// Use this for initialization
	void Awake () {
		this.startingPosition = new Vector3(0,3,-10);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y > 15) {
			this.ResetBat ();
		}

	}

	public void SwingBat() {
		this.rigidbody.AddForce((Vector3.up + Vector3.forward) * 1000000);
	}

	public void ResetBat() {
		this.rigidbody.velocity = Vector3.zero;
		this.transform.position = this.startingPosition;
		Debug.Log("starting position for batter " + this.startingPosition);
	}
}