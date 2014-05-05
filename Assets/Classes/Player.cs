using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Events;
using TouchScript.Gestures;

public class Player : MonoBehaviour {

	public Ball Ball;
	public GameObject Foot;

	public int Score = 0;
	public int maxPitches = 11;
	public int remainingPitches = 12; // because restart is called first on ball
	public bool isTutorialPitch = true;
	public int currentPitch = -2;

	public Vector2 flickPath;
	public Vector2 flickStart;
	
	public int multiplier = 1;
	
	public List<int> scores = new List<int>();
	
	public bool lastHitHomeRun = false;

	// Use this for initialization
	void Start () {
		for (var i = 0; i < 10; i++) {
			scores.Add(0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (remainingPitches == maxPitches){
			isTutorialPitch = true;
		} else {
			isTutorialPitch = false;
		}
	}
	
	public void ChangeScore(int delta) {
		if (!isTutorialPitch) {
			Score += delta * multiplier;
			scores[currentPitch] = delta * multiplier;
		}
	}
	
	public void HitHomeRun() {
		if (lastHitHomeRun) {
			multiplier++;
		} else {
			lastHitHomeRun = true;
		}
	}
	
	public void HitNotHomeRun() {
		lastHitHomeRun = false;
	}
	
	public void HitFoulOrStrike() {
		lastHitHomeRun = false;
		
		if (multiplier > 1)
			multiplier--;
	}
}
