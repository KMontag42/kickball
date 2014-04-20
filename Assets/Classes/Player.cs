using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Events;
using TouchScript.Gestures;

public class Player : MonoBehaviour {

	public Ball Ball;
	public GameObject Foot;

	public int Score = 0;

	public Vector2 flickPath;
	public Vector2 flickStart;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void flickHandler(object sender, GestureStateChangeEventArgs e)
	{
		FlickGesture flick = (sender as FlickGesture);

		if (e.State == Gesture.GestureState.Recognized) {
			flickPath = flick.ScreenFlickVector;

			Vector2 spd = ((sender as FlickGesture).ScreenFlickVector/(sender as FlickGesture).ScreenFlickTime);
			
			Vector3 flickDirection = new Vector3((sender as FlickGesture).ScreenFlickVector.x, (sender as FlickGesture).ScreenFlickVector.y, (sender as FlickGesture).ScreenFlickVector.y);
			
			Debug.Log("flickDirection  " + flickDirection);

			Debug.Log("screen position for ball center " + camera.WorldToScreenPoint(Ball.transform.position));

			Foot.rigidbody.AddForce(flickDirection);
		}
	}

	private void pressHandler(object sender, GestureStateChangeEventArgs e)
	{
		PressGesture press = (sender as PressGesture);

		if (e.State == Gesture.GestureState.Recognized) {
			flickStart = press.ScreenPosition;
			Debug.Log("screen position for press " + press.ScreenPosition);
			
			Debug.Log("screen to world point for press " + camera.ScreenToWorldPoint(press.ScreenPosition));

		}
	}

	private Vector2 Project(Vector2 line1, Vector2 line2, Vector2 toProject)
	{
		double m = (double)(line2.y - line1.y) / (line2.x - line1.x);
		double b = (double)line1.y - (m * line1.x);
		
		double x = (m * toProject.y + toProject.x - m * b) / (m * m + 1);
		double y = (m * m * toProject.y + m * toProject.x + b) / (m * m + 1);
		
		return new Vector2((float)x, (float)y);
	}

	Vector2 LineIntersectionPoint(Vector2 ps1, Vector2 pe1, Vector2 ps2, 
	                              Vector2 pe2)
	{
		// Get A,B,C of first line - points : ps1 to pe1
		float A1 = pe1.y-ps1.y;
		float B1 = ps1.x-pe1.x;
		float C1 = A1*ps1.x+B1*ps1.y;
		
		// Get A,B,C of second line - points : ps2 to pe2
		float A2 = pe2.y-ps2.y;
		float B2 = ps2.x-pe2.x;
		float C2 = A2*ps2.x+B2*ps2.y;
		
		// Get delta and check if the lines are parallel
		float delta = A1*B2 - A2*B1;
		if(delta == 0)
			return Vector2.zero;
		
		// now return the Vector2 intersection point
		return new Vector2(
			(B2*C1 - B1*C2)/delta,
			(A1*C2 - A2*C1)/delta
			);
	}
}
