// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Pitcher Pitcher;
	public Batter Batter;
	public Player Player;

	private bool destroyMe = false;
	public bool beingThrown = false;
	public bool beenHit = false;

	private Vector3 throwingVelocity;
	private float throwingTorque;

	private Vector3 hitVelocity;

	private float maxVelocity = 15.0f;
	private float sqrMaxVelocity = 15 * 15;

	public GameObject camera;
	private Vector3 cameraStart;
	private Quaternion cameraStartRotation;

	void Awake()
	{
		cameraStart = camera.transform.position;
		cameraStartRotation = camera.transform.rotation;
	}

	void OnCollisionEnter (Collision collision)
	{
		if (Pitcher != null) {
			if (collision.gameObject.name == "Single") {
				this.CatchBall ();
				this.Player.Score += 1;
				Debug.Log("hit ground - single");
			} else if (collision.gameObject.name == "Double") {
				this.CatchBall ();
				this.Player.Score += 2;
				Debug.Log("hit ground - double");
			} else if (collision.gameObject.name == "Triple") {
				this.CatchBall ();
				this.Player.Score += 3;
				Debug.Log("hit ground - triple");
			} else if (collision.gameObject.name == "Home Run") {
				this.CatchBall ();
				this.Player.Score += 4;
				Debug.Log("hit ground - home run");
			} else if (collision.gameObject.name == "Batter") {
				Debug.Log("bat hit");
				this.beingThrown = false;
				this.Batter.ResetBat();

//				this.hitVelocity = collision.rigidbody.velocity;

				this.beenHit = true;

				this.rigidbody.AddForce(this.hitVelocity);
			} else if (collision.gameObject.name == "Field") {
				this.CatchBall();
				this.Player.Score -= 1;
				Debug.Log ("hit ground - miss");
			}
		}
	}

	public void CatchBall()
	{
		this.ResetBall ();
		this.Pitcher.ReturnBall ();
	}

	public void ThrowBall(Vector3 velocity, float torque)
	{
		this.rigidbody.constraints = RigidbodyConstraints.None;

		this.throwingVelocity = velocity;

		this.throwingTorque = torque;

		this.beingThrown = true;
	}

	public void ResetBall()
	{
		this.beingThrown = false;
		this.beenHit = false;
		this.rigidbody.velocity = Vector3.zero;
		this.transform.position = new Vector3 (0, Random.Range(.5f,3), 25); // TODO : make this a var
		this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		this.Batter.ResetBat();
	}

	void Update()
	{
		if (this.beingThrown) {
			this.rigidbody.AddForce (this.throwingVelocity);
			this.rigidbody.AddTorque (Vector3.forward * this.throwingTorque);
		}

		if(this.beenHit && this.rigidbody.velocity.sqrMagnitude > this.sqrMaxVelocity){ // Equivalent to: rigidbody.velocity.magnitude > maxVelocity, but faster.
			// Vector3.normalized returns this vector with a magnitude 
			// of 1. This ensures that we're not messing with the 
			// direction of the vector, only its magnitude.
			this.rigidbody.velocity = this.rigidbody.velocity.normalized * maxVelocity;
		}

		if (this.beenHit) {
			camera.GetComponent<SmoothLookAt>().target = this.gameObject.transform;
			camera.GetComponent<SmoothFollow>().target = this.gameObject.transform;
		} else {
			camera.transform.position = this.cameraStart;
			camera.transform.rotation = this.cameraStartRotation;
			camera.GetComponent<SmoothLookAt>().target = null;
			camera.GetComponent<SmoothFollow>().target = null;
		}

		if (this.transform.position.z < -15) {
			this.ResetBall();
			this.Batter.ResetBat();
			this.Player.Score -= 1;
		}
	}
}