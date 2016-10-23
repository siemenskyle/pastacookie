using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int damage = 20;
	public string target = "enemy";

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag != target) {
			return;
		}
		if (target == "enemy") {
			col.gameObject.GetComponent<EnemyHealth> ().alterHealth (-damage);
			Destroy (gameObject);
		} else if (target == "Player") {
			col.gameObject.GetComponent<PlayerManagement> ().repairDamageHull (-damage);
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
