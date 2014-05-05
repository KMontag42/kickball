using UnityEngine;
using System.Collections;

public class KickballGUI : MonoBehaviour
{

	public Pitcher Pitcher;
	public Player Player;
	public Ball Ball;
	
	public GUIStyle throwPitch;

	//private float ballMaxSpeed = 10000;

//	private bool hasSwung = false;

	// Use this for initialization
	void Start ()
	{
		if (!Player) {
			Debug.LogError ("No player on ball");
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnGUI ()
	{
		if (Ball.beenHit == false && Ball.beingThrown == false && Player.remainingPitches > 0) {
			if (GUI.Button (new Rect ((Screen.width / 2) - 125, (Screen.height / 2) - 75, 250, 150), "Throw The Pitch!")) {
				Pitcher.DecidePitch ();
			}
		}

		if (Player.remainingPitches <= 0) {
		
			if (Skillz.tournamentIsInProgress()) {
				Skillz.displayTournamentResultsWithScore(Player.Score);
			} else {
				if (GUI.Button (new Rect ((Screen.width / 2) - 125, (Screen.height / 2) - 75, 250, 150), "New Game?")) {
					Player.remainingPitches = Player.maxPitches + 1;
					Player.Score = 0;
					Ball.ResetBall ();
				}
			}
		}

		if (Player) {
			for (var i = 0; i <= Player.scores.Count; i++) {
				if (i == Player.scores.Count) {
					GUI.Box(new Rect(30 + (20*i), 10, 25, 20), Player.Score.ToString());
				} else {
					switch (Player.scores[i]) {
						case -1:
							GUI.Box (new Rect(10 + (20*i), 10, 15, 20), "X");
							break;
						case 0:
							GUI.Box (new Rect(10 + (20*i), 10, 15, 20), "");	
							break;
						case 5:
							GUI.Box (new Rect(10 + (20*i), 10, 15, 20), "H");
							break;
						default:
			            	GUI.Box (new Rect(10 + (20*i), 10, 15, 20), Player.scores[i].ToString());
			            	break;
					}
					
				}
			}
			
			GUI.Box (new Rect (10, 35, 100, 20), "Remaining: " + Player.remainingPitches.ToString ());
			GUI.Box (new Rect (10, 60, 100, 20), "Multiplier: " + Player.multiplier.ToString ());
		}
		
		
		
	}
}

