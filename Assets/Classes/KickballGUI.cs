using UnityEngine;
using System.Collections;

public class KickballGUI : MonoBehaviour
{

	public Pitcher Pitcher;
	public Batter Batter;
	public Player Player;
	public Ball Ball;
	
	private Ray yellowRay;
	private RaycastHit theHit;
	private int ignoreMask;
	
	private Vector3 onTHINGPointBegin;
	private Vector3 onTHINGPointEnd;

	private float ballMaxSpeed = 10000;

	private bool hasSwung = false;

	private Time startTime;

	// Use this for initialization
	void Start ()
	{
		if (!this.Player) {
			Debug.LogError("No player on ball");
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (10, 10, 250, 150), "Decide Pitch")) {
			this.Pitcher.DecidePitch ();
		} else {
			if (this.Ball && this.Batter && !this.hasSwung) {
				if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
					if ( Input.touches.Length == 0 ) return;
					
					yellowRay = camera.ScreenPointToRay( Input.touches[0].position );
					Debug.Log("yellowRay " + yellowRay);
					
					if ( ! collider.Raycast (yellowRay, out theHit, 10.0f ) ) return;

					onTHINGPointEnd = theHit.point;
					Debug.Log("onTHINGPointEnd " + onTHINGPointEnd);


					if ( Input.touches[0].phase != TouchPhase.Moved ) return;

					startedAtGlasswise = Input.touches[0].position - Input.touches[0].deltaPosition;
					Debug.Log("startedAtGlasswise " + startedAtGlasswise);

					yellowRay = camera.ScreenPointToRay( startedAtGlasswise );
					Debug.Log("yellowRay " + yellowRay);

					onTHINGPointBegin = onTHINGPointEnd; // our default political position
					Debug.Log("onTHINGPointBegin " + onTHINGPointBegin);

					if ( collider.Raycast (yellowRay, out theHit, 10.0f ) ) {
						onTHINGPointBegin = theHit.point;
						Debug.Log("onTHINGPointBegin if " + onTHINGPointBegin);
					}

					if ( startedAtGlasswise.x < 0.1 * Screen.width ) return;

					Debug.Log("past the screen.width if block at the end");

					if ( Input.touches[0].deltaTime == 0.0 ) return; // just in case

					Debug.Log("sending to moveListThisInRealWorld " + (onTHINGPointEnd - onTHINGPointBegin) / Input.touches[0].deltaTime);
					moveLikeThisInRealWorld( (onTHINGPointEnd - onTHINGPointBegin) / Input.touches[0].deltaTime );

				} else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
					this.hasSwung = true;
					Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
//					this.Batter.rigidbody.AddForce(0,0, touchDeltaPosition.y * ballMaxSpeed);

				}
			} else if (this.hasSwung) {
				this.hasSwung = false;
			}
		}

//		if (GUI.Button (new Rect (10, 70, 100, 50), "Swing Bat")) {
//			this.Batter.SwingBat();
//		}

		if (this.Player) {
			GUI.Label (new Rect (110, 10, 50, 50), this.Player.Score.ToString ());
		}
	}

	//////////////////////////////////////////////////////////
	//
	//
	// in this code we are getting much more closer to usable touch interaction,
	// coz we are moving from the GLASS to the REAL UNIVERSE
	// to quote a famous film this is the first step in to a bigger world !
	
	// please note, i used "THING" in this example code.
	// for example ...... in the code I found this in, it was "Cloud",
	// in that title the user would swipe on "clouds" for some reason
	// so the variables were of course named onCloudPointBegin, and so on.
	// clouds are in fact about 2000 meters long, so in that example the
	// ultimate values would be something like, say 500 m/s or whatever
	// ie the user would be swiping (in the real world) at say 500 m/s
	
	private Vector3 startedAtGlasswise;
	
	void moveLikeThisInRealWorld(Vector3 dd )
	{
		// this is an ACTUAL REAL WORLD MOVE
		
		// for instance:
		// if you are "dragging an object around with your finger"
		
		// in that example your job is entirely DONE, just move the object
		// by this vector. it's really that simple and beautiful.
		
		// (so in the cloud example, incredibly, you could simply move the
		// cloud, UFO or whatever it was by say 728 meters or whatever value
		// emerges from this "glass to real universe" swiping code)
		
		// To be clear we've looked at velocity here, of course often you may need
		// just the position change, i.e not considering the time.
		// however, in practice you almost always have to consider in some way
		// the time taken, to see if it is meaningful

		this.Batter.transform.position = dd;

		Debug.Log ("dd vector " + dd);

	}


}

