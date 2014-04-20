using UnityEngine;
using System.Collections;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Events;

public class Batter : MonoBehaviour {

	private bool swinging;

	private Vector3 startingPosition;

	public Ball Ball;

	private Time startTime;

	// Use this for initialization
	void Awake () {
		this.startingPosition = transform.position;

		GetComponent<FlickGesture>().StateChanged += flickHandler;
		GetComponent<PanGesture>().StateChanged += pressHandler;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.z > 25) {
			this.ResetBat ();
		}
	}

	public void SwingBat() {
		float multiplier = Random.Range (1000000, 5000000);

		Debug.Log(multiplier);
		if (this.Ball && (this.Ball.beingThrown || this.Ball.beenHit))
			this.rigidbody.AddForce(Vector3.forward * multiplier);
	}

	public void ResetBat() {
		this.rigidbody.velocity = Vector3.zero;
		this.transform.position = this.startingPosition;
		Debug.Log("starting position for batter " + this.startingPosition);
	}

	private void pressHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
	{
		//rigidbody.velocity = Vector3.zero;
		if ((sender as PanGesture).ScreenPosition.x != null) {
			Vector3 moveDelta = (sender as PanGesture).WorldDeltaPosition;
			moveDelta.y = 0;
			transform.position += moveDelta;
		}
	}
	
	private void flickHandler(object sender, GestureStateChangeEventArgs e)
	{
		if (e.State == Gesture.GestureState.Recognized)
		{
			Vector2 spd = ((sender as FlickGesture).ScreenFlickVector/(sender as FlickGesture).ScreenFlickTime);
			Debug.Log(spd);
			//speed = new Vector3(spd.y, -spd.x, 0);
		}
	}
}
