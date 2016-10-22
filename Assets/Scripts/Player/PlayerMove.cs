using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
	public bool altControl;

	Rigidbody2D rbody;
	Animator anim;

    // Use this for initialization
    void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is bad dont use it
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W))
        {
			rbody.AddForce(transform.up * speed);
			anim.SetBool ("Forward", true);
        }

        // Reverse
		if (Input.GetKey(KeyCode.S))
        {
			rbody.AddForce(-transform.up * speed);
			anim.SetBool ("Reverse", true);
        }

        // Rotate Left or strafe left
        if (Input.GetKey(KeyCode.Q))
        {
			if (altControl) {
				transform.Rotate (0, 0, rotationSpeed);
				anim.SetBool ("RotateLeft", true);
			} else {
				rbody.AddForce (-transform.right * speed);
				anim.SetBool ("StrafeLeft", true);
			}
        }

        // Rotate Right or strafe right
        if (Input.GetKey(KeyCode.E))
        {
			if (altControl) {
				transform.Rotate (0, 0, -rotationSpeed);
				anim.SetBool ("RotateRight", true);
			} else {
				rbody.AddForce (transform.right * speed);
				anim.SetBool ("StrafeRight", true);
			}
		}

		// Strafe Left or rotate left
		if (Input.GetKey(KeyCode.A))
		{
			if (altControl) {
				rbody.AddForce (-transform.right * speed);
				anim.SetBool ("StrafeLeft", true);
			} else {
				transform.Rotate (0, 0, rotationSpeed);
				anim.SetBool ("RotateLeft", true);
			}
		}

		// Strafe Right or rotate right
		if (Input.GetKey(KeyCode.D))
		{
			if (altControl) {
				rbody.AddForce (transform.right * speed);
				anim.SetBool ("RotateRight", true);
			} else {
				transform.Rotate (0, 0, -rotationSpeed);
				anim.SetBool ("RotateRight", true);
			}
		}
    }
}
