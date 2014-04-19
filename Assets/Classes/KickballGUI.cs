using UnityEngine;
using System.Collections;

public class KickballGUI : MonoBehaviour
{

	public Pitcher Pitcher;
	public Batter Batter;
	public Player Player;
	public Ball Ball;

	private float ballMaxSpeed = 10000;

	private bool hasSwung = false;

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
				/* if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {

					Vector2 touchPosition = Input.GetTouch(0).position;

					this.Batter.transform.position = new Vector3(touchPosition.x / 5,this.Batter.transform.position.y,this.Batter.transform.position.z);

				} else */if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
					// Get movement of the finger since last frame
					Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
					
					this.Batter.rigidbody.AddForce(0,0, touchDeltaPosition.y * ballMaxSpeed);
						
//					this.Batter.rigidbody.AddTorque(0, /*-touchDeltaPosition.y * speed*/ -touchDeltaPosition.x, 0);

					/* (this.Ball.beingThrown || this.Ball.beenHit) && */
				} else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
					this.hasSwung = true;
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
}

