using UnityEngine;
using System.Collections;

public class EnemyHealth : Entity {

	//public int health;

	// Use this for initialization
	void Start () {
		health = 100;
	}

	void FixedUpdate() {
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

}
