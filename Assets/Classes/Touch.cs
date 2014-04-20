using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	public Batter Batter;

	// Use this for initialization
	void Start () {

		if (!Batter) {
			Debug.LogError("Check Touch gameObject");
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
