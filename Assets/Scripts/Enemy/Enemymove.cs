using UnityEngine;
using System.Collections;

public class Enemymove : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public Transform playerLocation;
	public float sightRange;
	public float effectiveRange;
	public float closeRange;
	public bool strafeLeft;
	public bool strafeRight;

	Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
	}

	// Update is bad dont use it
	/*
	 * Will seek towards player when in sight range
	 * will seek away from player when it is at close range
	 * will optionally circle strafe in selected direction if at optimal range
	 **/
	void FixedUpdate () {
		float distance = Vector3.Distance (transform.position, playerLocation.position);
		float ahead = Vector3.Dot (transform.up, (playerLocation.position - transform.position).normalized);
		float direction = Vector3.Dot (transform.right, (playerLocation.position - transform.position).normalized);

		if (distance < sightRange) {
			if (direction > 0.05) {
				transform.Rotate (0, 0, -rotationSpeed);
			} else if (direction < 0.05) {
				transform.Rotate (0, 0, rotationSpeed);
			}

			float speedForce = speed;
			Vector3 forceDirection = transform.up;
			if (distance < closeRange)
				speedForce *= -1;
			else if (distance < effectiveRange){
				if (strafeLeft)
					forceDirection = -transform.right;
				else if (strafeRight)
					forceDirection = transform.right;
				else
					speedForce *= 0;
			}
			
			
			if (ahead > 0.25) 
				rbody.AddForce (forceDirection * speedForce);
			
		}
	}
}
