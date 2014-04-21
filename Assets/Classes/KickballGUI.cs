using UnityEngine;
using System.Collections;

public class KickballGUI : MonoBehaviour
{

	public Pitcher Pitcher;
	public Player Player;
	public Ball Ball;

	//private float ballMaxSpeed = 10000;

//	private bool hasSwung = false;

	// Use this for initialization
	void Start ()
	{
		if (!Player) {
			Debug.LogError("No player on ball");
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnGUI()
	{
		if (Ball.beenHit == false && Ball.beingThrown == false)
		if (GUI.Button (new Rect ((Screen.width / 2) - 125, (Screen.height / 2) - 75, 250, 150), "Throw The Pitch!")) {
				Pitcher.DecidePitch ();
			}

		if (GUI.Button (new Rect((Screen.width / 6) - 25, (Screen.height / 8) - 12.5f, 50, 25), "Reset Ball")) {
			Ball.ResetBall();
		}
//		if (GUI.Button (new Rect (10, 70, 100, 50), "Swing Bat")) {
//			Batter.SwingBat();
//		}

		if (Player) {
			GUI.Label (new Rect (150, 10, 50, 50), Player.Score.ToString ());
			GUI.Label (new Rect (80, 10, 50, 50), Player.remainingPitches.ToString ());
		}
	}
}

