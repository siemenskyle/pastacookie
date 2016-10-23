using UnityEngine;
using System.Collections;

public class PlanetKillScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PlayerManagement> ().repairDamageHull (-10000);
		}
	}
}
