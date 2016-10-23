using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	private int damage;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "enemy") {
			col.gameObject.GetComponent<Entity> ().alterHealth(-damage);
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	public int setDamage(int newDamage) {
		damage = newDamage;
		return damage;
	}

	public int getDamage() {
		return damage;
	}
}
