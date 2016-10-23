using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {
	/// <summary>
	/// It's called PlanetScript but it actually goes on moving objects. 
	/// </summary>
	// Use this for initialization

	public bool inGravityWell;
	public GUIText warning;

	public float smallDistance = 20.0f; //Distance at which you start getting affected by gravity
	public float smallGravity = 6.0f; //strength at which the gravity pulls

	public float medDistance = 30.0f;
	public float medGravity = 8.0f;

	public float largeDistance = 50.0f;
	public float largeGravity = 10.0f;

	public float exLargeDistance = 80.0f;
	public float exLargeGravity = 15.0f;

	public float sunDistance = 300.0f;
	public float sunGravity = 30.0f;

	private GameObject[] planets1; 
	private GameObject[] planets2; 
	private GameObject[] planets3; 
	private GameObject[] planets4; 
	private GameObject[] Sun; 

	void Start () {
		planets1 = GameObject.FindGameObjectsWithTag ("Planet1");
		planets2 = GameObject.FindGameObjectsWithTag ("Planet2");
		planets3 = GameObject.FindGameObjectsWithTag ("Planet3");
		planets4 = GameObject.FindGameObjectsWithTag ("Planet4");
		Sun = GameObject.FindGameObjectsWithTag ("Sun");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		warning.text = "";
		AddGravity (smallDistance, smallGravity, planets1);
		AddGravity (medDistance, medGravity, planets2);
		AddGravity (largeDistance, largeGravity, planets3);
		AddGravity (exLargeDistance, exLargeGravity, planets4);
		AddGravity (sunDistance, sunGravity, Sun);
	}

	void AddGravity(float maxDistance, float force, GameObject[] bodies){
		foreach (GameObject planet in bodies) {
			float distance = Vector3.Distance (planet.transform.position, transform.position);
			if (distance <= maxDistance) {
				Vector3 v = planet.transform.position - transform.position;
				GetComponent<Rigidbody2D> ().AddForce (v.normalized * (1.0f - distance / maxDistance) * force);
			}
		}
		foreach (GameObject planet in bodies) {
			float distance = Vector3.Distance (planet.transform.position, transform.position);
			if (distance <= maxDistance) {
				warning.text = "WARNING: GRAVITY WELL";
				break;
			}
		}

	}
}
