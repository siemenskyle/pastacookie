using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int damage = 0;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "enemy") {
			col.gameObject.GetComponent<EnemyHealth> ().alterHealth(-damage);
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
}
