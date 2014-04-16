using UnityEngine;
using System.Collections;

public class KickballGUI : MonoBehaviour
{

	public Pitcher Pitcher;
	public Batter Batter;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (10, 10, 100, 50), "Decide Pitch")) {
			this.Pitcher.DecidePitch();
		}

		if (GUI.Button (new Rect (10, 70, 100, 50), "Swing Bat")) {
			this.Batter.SwingBat();
		}
	}
}

