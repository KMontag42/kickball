using UnityEngine;
using System.Collections;

using System;
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

	public enum PitcherCommand {
		Decide,
		Throw,
		Catch
	}

	private Action[,] fsm;


	// Use this for initialization
	void Awake () {
		if (!Ball) {
			Debug.LogError("No ball");
		}

		/* init state machine calls
		 * 
		 */
		this.fsm = new Action[3, 3] {
			// Decide				Throw			Catch
			{this.ThrowBall,		null,			this.DecidePitch	}, // Holding
			{null,					this.DoHit,		null				}, // Throwing
			{null,					null, 			this.ReturnBall 	} // Catching
		};

		GameObject.Instantiate (this.Ball);

		this.State = PitcherState.Holding;
	}

	void Start()
	{
		this.ProcessEvent (PitcherCommand.Decide);
	}

	void ProcessEvent(PitcherCommand cmd) {
		if (this.fsm != null)
			this.fsm [(int)this.State, (int)cmd].Invoke ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ThrowBall() {
		Debug.Log (this.State);
		Debug.Log (this.Ball.rigidbody.velocity);

		this.State = PitcherState.Throwing;

		this.ProcessEvent (PitcherCommand.Throw);
	}

	void DecidePitch() {
		Debug.Log (this.State);
		// do some shit to make the pitch hard, then call decided

		this.ProcessEvent (PitcherCommand.Decide);
	}

	void DoHit() {
		Debug.Log (this.State);

		this.Ball.ThrowBall();

		this.State = PitcherState.Catching;
	}

	// called when the ball hits the ground, either on the field on at the catcher
	public void CatchBall() {
		Debug.Log (this.State);
		Debug.Log (this.Ball);

		this.Ball.CatchBall();

		Debug.Log ("moved ball");
		Debug.Log (this.Ball.transform.position);
		this.ProcessEvent (PitcherCommand.Catch);
	}

	void ReturnBall() {
		Debug.Log ("return ball");
		this.State = PitcherState.Holding;
		this.ProcessEvent (PitcherCommand.Catch);
	}
}
