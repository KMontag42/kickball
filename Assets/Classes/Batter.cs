using UnityEngine;
using System.Collections;

public class Batter : MonoBehaviour {

	private bool swinging;

	private Vector3 startingPosition;

	// Use this for initialization
	void Awake () {
		this.startingPosition = new Vector3(-.55f,3,-10);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y > 15) {
			this.ResetBat ();
		}

	}

	public void SwingBat() {
		float multiplier = Random.Range (1000000, 5000000);

		Debug.Log(multiplier);

		this.rigidbody.AddForce((Vector3.up + Vector3.forward) * multiplier);
	}

	public void ResetBat() {
		this.rigidbody.velocity = Vector3.zero;
		this.transform.position = this.startingPosition;
		Debug.Log("starting position for batter " + this.startingPosition);
	}
}
