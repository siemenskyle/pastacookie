using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {
	/// <summary>
	/// It's called PlanetScript but it actually goes on moving objects. 
	/// </summary>
	// Use this for initialization

	public float maxGravityDistance = 4.0f;
	public float maxGravity = 35.0f;

	private GameObject[] planets; 

	void Start () {
		planets = GameObject.FindGameObjectsWithTag ("Planet");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach (GameObject planet in planets) {
			float distance = Vector3.Distance (planet.transform.position, transform.position);
			if (distance <= maxGravityDistance) {
				Vector3 v = planet.transform.position - transform.position;
				GetComponent<Rigidbody2D>().AddForce (v.normalized * (1.0f - distance / maxGravityDistance) * maxGravity);
			}
		}
	}
}
