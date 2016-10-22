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
			Vector2 cursorPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			Vector2 cursorDirection = new Vector2(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y);
			shoot (transform.position, cursorDirection);
		}
	}

	void shoot(Vector3 startingPosition, Vector2 startingAngle) {
		// Make current ships movement added to the velocity
		Vector2 startingVelocity = transform.GetComponent<Rigidbody2D> ().velocity;

		// Add bullet shoot speed to the velocity
		Vector3 addedVelocity = startingAngle.normalized * velocity;

		float angle = Mathf.Atan2(startingAngle.y, startingAngle.x) * Mathf.Rad2Deg - 90f;

		// Instantiate the bullet
		startingVelocity = new Vector2 (startingVelocity.x + addedVelocity.x, startingVelocity.y + addedVelocity.y);
		GameObject spawnedBullet = (GameObject)Instantiate(bulletPrefab, startingPosition, Quaternion.Euler(new Vector3(0, 0, angle)));
		spawnedBullet.GetComponent<Rigidbody2D> ().velocity = startingVelocity;
	}
}
