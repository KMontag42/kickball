using UnityEngine;
using System.Collections;

public class ExtraPitch : MonoBehaviour {

	private GameObject homeRunZone;
	// hrz z length is 350 255 -> 605
	// hrz width is 200 -100 -> 100


	// Use this for initialization
	void Start () {
		homeRunZone = GameObject.Find("Home Run").gameObject;
		renderer.enabled = false;
		collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetPosition()
	{
		transform.position = new Vector3(Random.Range(-100,100), 10, Random.Range(255, 605));
		renderer.enabled = true;
		collider.enabled = true;
	}

	public void BallHit()
	{
		renderer.enabled = false;
		collider.enabled = false;
	}
}
