using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
	public bool altControl;
	public bool boost;
	public bool moving;
	public float boostMult;
	public float time;
	public int boostCost;
	public int boostTick;

	Rigidbody2D rbody;
	Animator anim;

	Animator br,bm,bl;

    // Use this for initialization
    void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		bm = GetComponentsInChildren<Animator>()[1];
		bl = GetComponentsInChildren<Animator>()[2];
		br = GetComponentsInChildren<Animator>()[3];
		time = 0;
		if (boostCost == 0) {
			boostCost = 1;
		}
		if (boostTick == 0) {
			boostTick = 1;
		}

	}
	
	// Update is bad dont use it
	void FixedUpdate () {
		moving = false;
		bm.SetBool ("On", false);
		bl.SetBool ("On", false);
		br.SetBool ("On", false);

		if (Input.GetKey (KeyCode.LeftShift))
		{
			boost = true;
			time = time + Time.deltaTime;
			if (time >= boostTick) {
				this.gameObject.GetComponent<PlayerManagement> ().alterEnergy (-boostCost);
				time = 0;
			}
			if (this.gameObject.GetComponent<PlayerManagement> ().getEnergy () == 0) {
				boost = false;
			}
		}
		else
			boost = false;

		if (Input.GetKey (KeyCode.W)) {
			moving = true;
			float thisspeed = speed;
			if (boost)
				thisspeed *= boostMult;
			
			rbody.AddForce (transform.up * thisspeed);
			bm.SetBool ("On", true);
		} else {
			boost = false;
		}

        // Reverse
		if (Input.GetKey(KeyCode.S))
        {
			moving = true;
			rbody.AddForce(-transform.up * speed);
        }

        // Rotate Left or strafe left
        if (Input.GetKey(KeyCode.Q))
        {
			moving = true;
			if (altControl) {
				transform.Rotate (0, 0, rotationSpeed);
				br.SetBool("On", true);
			} else {
				rbody.AddForce (-transform.right * speed);
			}
        }

        // Rotate Right or strafe right
        if (Input.GetKey(KeyCode.E))
        {
			moving = true;
			if (altControl) {
				transform.Rotate (0, 0, -rotationSpeed);
				bl.SetBool("On", true);
			} else {
				rbody.AddForce (transform.right * speed);
				//anim.SetBool ("StrafeRight", true);
			}
		}

		// Strafe Left or rotate left
		if (Input.GetKey(KeyCode.A))
		{
			moving = true;
			if (altControl) {
				rbody.AddForce (-transform.right * speed);
			} else {
				transform.Rotate (0, 0, rotationSpeed);
				br.SetBool("On", true);
			}
		}

		// Strafe Right or rotate right
		if (Input.GetKey(KeyCode.D))
		{
			moving = true;
			if (altControl) {
				rbody.AddForce (transform.right * speed);
			} else {
				transform.Rotate (0, 0, -rotationSpeed);
				bl.SetBool("On", true);
			}
		}
    }
}
