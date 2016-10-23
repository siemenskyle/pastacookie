using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileScript : MonoBehaviour {

	LinkedList<GameObject> targets;
	GameObject currentTarget;
	public float rotationSpeed;
	public float speed;
	private float largeRadius = 100f;
	private float smallRadius = 50f;

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag != "enemy") {
			return;
		}
		gameObject.GetComponent<CircleCollider2D> ().radius = largeRadius;
		if (!targets.Contains (col.gameObject)) {
			targets.AddLast (col.gameObject);
			if (targets.Count == 1) {
				currentTarget = col.gameObject;
			}
		} else if (Vector3.Distance (col.gameObject.transform.position, gameObject.transform.position) <= 2f) {
			foreach (GameObject enemy in targets) {
				col.gameObject.GetComponent<EnemyHealth> ().alterHealth (-100);
				Destroy (gameObject);
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
			gameObject.GetComponent<CircleCollider2D> ().radius = smallRadius;
		}
	}

	// Use this for initialization
	void Awake () {
		targets = new LinkedList<GameObject>();
		rotationSpeed = 5f;
		speed = 20f;
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
			//Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
			float addedSpeed = Vector3.Distance(currentTarget.transform.position, transform.position) < 8f ? Vector3.Distance(currentTarget.transform.position, transform.position) : 8f;
			gameObject.GetComponent<Rigidbody2D>().AddForce (transform.up * speed/addedSpeed);
		}
	}
}
