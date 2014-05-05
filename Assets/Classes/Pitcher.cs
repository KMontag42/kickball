using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Text;



public class Pitcher : MonoBehaviour {

	public Ball Ball;
	public Player Player;

	// Use this for initialization
	void Start () {
		if (!Ball) {
			Debug.LogError("Check prefab");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ThrowBall() {
		//this.Ball.renderer.enabled = true;

		/* TODO :
		 *	- seed random values for the spin, and the velocity
		 *  - use these seeds to determine the offset of the ball
		 *  - think about having 'balls' as well where the ball spins out of hte strike zone
		 *  - think about how to animate the pitcher
		 *  - think about the tutorial
		 *     - variable to turn off the warm up pitch
		 *  - touch up warm up pitch to feel more 'natural'
		 *  - wind?
		 */

		float spin = Random.Range(0f,1f) > .5f ? Random.Range(0f,.5f) : -Random.Range(0f,.5f);

		Debug.Log(spin);
		
		float ballDeltaX = Mathf.Abs(spin) > .1f ? (spin * 3) : 0;
		
		Debug.Log(ballDeltaX);
		
		Vector3 throwVelocity = Vector3.back * Random.Range (250, 300);
		
		
		if (ballDeltaX > 0) {
			Ball.transform.position += Vector3.left * 1/ballDeltaX;
		} else if (ballDeltaX < 0) {
			Ball.transform.position += Vector3.right * 1/ballDeltaX;
		}

		this.Ball.ThrowBall (throwVelocity, spin);
	}

	public void DecidePitch() {
		this.ThrowBall ();
		Player.currentPitch++;
	}


}
