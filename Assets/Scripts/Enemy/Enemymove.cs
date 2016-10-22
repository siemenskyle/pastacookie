using UnityEngine;
using System.Collections;

public class Enemymove : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public Transform playerLocation;

	Rigidbody2D rbody;
	Animator anim;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}

	// Update is bad dont use it
	void FixedUpdate () {
		Vector3 rotateDir = transform.position - playerLocation.position;

		float ahead = Vector3.Dot (transform.up, (playerLocation.position - transform.position).normalized);
		float direction = Vector3.Dot (transform.right, (playerLocation.position - transform.position).normalized);
		Debug.Log( ahead );

		if (direction > 0.05) {
			transform.Rotate (0, 0, -rotationSpeed);
			anim.SetBool ("RotateRight", true);
		} else if (direction < 0.05){
			transform.Rotate (0, 0, rotationSpeed);
			anim.SetBool ("RotateLeft", true);
		}

		if (ahead > 0.25) {
			rbody.AddForce (transform.up * speed);
			anim.SetBool ("Forward", true);	
		}
	}
}
