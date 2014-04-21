using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Events;
using TouchScript.Gestures;

public class Player : MonoBehaviour {

	public Ball Ball;
	public GameObject Foot;

	public int Score = 0;
	public int maxPitches = 10;
	public int remainingPitches = 11; // because restart is called first on ball

	public Vector2 flickPath;
	public Vector2 flickStart;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
