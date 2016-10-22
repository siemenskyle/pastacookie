using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileScript : MonoBehaviour {

	LinkedList<GameObject> targets;
	GameObject currentTarget;
	public float rotationSpeed;
	public float speed;

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag != "enemy") {
			return;
		}
		if (!targets.Contains (col.gameObject)) {
			targets.AddLast (col.gameObject);
			if (targets.Count == 1) {
				currentTarget = col.gameObject;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag != "enemy") {
			return;
		}
		targets.Remove (col.gameObject);
		if (targets.Count > 0) {
			currentTarget = targets.First.Value;
		} else {
			currentTarget = null;
		}
	}

	// Use this for initialization
	void Awake () {
		targets = new LinkedList<GameObject>();
		rotationSpeed = 5f;
		speed = 10f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (currentTarget) {
			float direction = Vector3.Dot (transform.right, (currentTarget.transform.position - transform.position).normalized);

			if (direction > 0.05) {
				transform.Rotate (0, 0, -rotationSpeed);
				//anim.SetBool ("RotateRight", true);
			} else if (direction < 0.05){
				transform.Rotate (0, 0, rotationSpeed);
				//anim.SetBool ("RotateLeft", true);
			}
			Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
			gameObject.GetComponent<Rigidbody2D>().AddForce (transform.up * speed);
		}
	}
}
