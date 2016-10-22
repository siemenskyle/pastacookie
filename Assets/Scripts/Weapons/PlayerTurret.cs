using UnityEngine;
using System.Collections;

public class PlayerTurret : MonoBehaviour {

	Resources resources;
	public GameObject bulletPrefab;
	public float velocity;

	// Use this for initialization
	void Start () {
		//this.resources = gameObject.GetComponent<Resources> ();
	}

	void FixedUpdate() {
		if (Input.GetKeyDown ("space")) {
			shoot (transform.position, 0f);
		}
	}

	void shoot(Vector3 start, float angle) {
		// Set inital position
		start += transform.up.normalized;
		Vector2 startingVelocity = transform.GetComponent<Rigidbody2D> ().velocity;
		Vector3 addedVelocity = transform.up.normalized * velocity;
		startingVelocity = new Vector2 (startingVelocity.x + addedVelocity.x, startingVelocity.y + addedVelocity.y);
		GameObject spawnedBullet = (GameObject)Instantiate(bulletPrefab, start, transform.rotation);
		spawnedBullet.GetComponent<Rigidbody2D> ().velocity = startingVelocity;

	}
}
