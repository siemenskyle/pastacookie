﻿using UnityEngine;
using System.Collections;

public class PlayerMissile : MonoBehaviour {

	Resources resources;
	public GameObject missilePrefab;
	public float velocity;

	// Use this for initialization
	void Start () {
		//this.resources = gameObject.GetComponent<Resources> ();
	}

	public void shoot(int damage) {
		Vector2 startingPosition = GetWorldPositionOnPlane((Input.mousePosition ), 0f);
		Vector2 startingAngle = new Vector2(startingPosition.x - transform.position.x, startingPosition.y - transform.position.y);
		// Make current ships movement added to the velocity
		Vector2 startingVelocity = transform.GetComponent<Rigidbody2D> ().velocity;

		// Add bullet shoot speed to the velocity
		Vector3 addedVelocity = startingAngle.normalized * velocity;

		float angle = Mathf.Atan2(startingAngle.y, startingAngle.x) * Mathf.Rad2Deg - 90f;

		// Instantiate the bullet
		startingVelocity = new Vector2 (startingVelocity.x + addedVelocity.x, startingVelocity.y + addedVelocity.y);
		GameObject spawnedBullet = (GameObject)Instantiate(missilePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
		spawnedBullet.GetComponent<Rigidbody2D> ().velocity = startingVelocity;
		MissileScript newMissileScript = spawnedBullet.AddComponent<MissileScript> ();
		newMissileScript.setDamage (damage);
		DestroyObject (spawnedBullet, 10f);
	}

	public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}
}
