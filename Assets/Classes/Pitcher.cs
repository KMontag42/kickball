using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pitcher : MonoBehaviour {

	public Ball Ball;

	public enum PitcherState {
		Holding,
		Throwing,
		Catching
	}

	public PitcherState State {get; set;}

	public Batter Batter;

	// Use this for initialization
	void Start () {
		if (!Ball || !Batter) {
			Debug.LogError("Check prefab");
		}

		this.Ball.ResetBall ();

		this.State = PitcherState.Holding;

//		this.DecidePitch ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ThrowBall() {
		this.State = PitcherState.Catching;

		this.Ball.renderer.enabled = true;

		Vector3 throwVelocity = Vector3.back * Random.Range (10, 25);

		this.Ball.ThrowBall (throwVelocity, Random.Range (0,50));
	}

	public void DecidePitch() {
		this.State = PitcherState.Throwing;

		this.ThrowBall ();
	}

	public void ReturnBall() {
//		this.Ball.renderer.enabled = false;

		this.Batter.ResetBat ();

		this.State = PitcherState.Holding;
	}
}
