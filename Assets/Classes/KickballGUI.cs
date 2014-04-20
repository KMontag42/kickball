using UnityEngine;
using System.Collections;

public class KickballGUI : MonoBehaviour
{

	public Pitcher Pitcher;
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
		}

		if (GUI.Button (new Rect(10, 170, 250, 50), "Reset Ball")) {
			this.Ball.ResetBall();
		}
//		if (GUI.Button (new Rect (10, 70, 100, 50), "Swing Bat")) {
//			this.Batter.SwingBat();
//		}

		if (this.Player) {
			GUI.Label (new Rect (110, 10, 50, 50), this.Player.Score.ToString ());
		}
	}
}

