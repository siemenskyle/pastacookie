using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
	Rigidbody2D rbody;
	public bool alt_control;

    // Use this for initialization
    void Start () {
		rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W))
        {
			rbody.AddForce(transform.up * speed);
        }

        // Reverse
		if (Input.GetKey(KeyCode.S))
        {
			rbody.AddForce(-transform.up * speed);
        }

        // Rotate Left or strafe left
        if (Input.GetKey(KeyCode.Q))
        {
			if(alt_control)
            	transform.Rotate(0, 0, rotationSpeed);
			else 
				rbody.AddForce(-transform.right * speed);
        }

        // Rotate Right or strafe right
        if (Input.GetKey(KeyCode.E))
        {
			if(alt_control)
            	transform.Rotate(0, 0, -rotationSpeed);
        	else
				rbody.AddForce(transform.right * speed);
		}

		// Strafe Left or rotate right
		if (Input.GetKey(KeyCode.A))
		{
			if(alt_control)
				rbody.AddForce(-transform.right * speed);
			else
				transform.Rotate(0, 0, rotationSpeed);
		}

		// Strafe Right or rotate right
		if (Input.GetKey(KeyCode.D))
		{
			if(alt_control)
				rbody.AddForce(transform.right * speed);
			else
				transform.Rotate(0, 0, -rotationSpeed);

		}
    }
}
