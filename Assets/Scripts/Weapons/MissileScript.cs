using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileScript : MonoBehaviour {

	LinkedList<GameObject> targets;
	GameObject currentTarget;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag != "enemy") {
			return;
		}
		targets.AddLast(col.gameObject);
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag != "enemy") {
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
	void Start () {
		targets = new LinkedList<GameObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (currentTarget) {

		}
	}
}
