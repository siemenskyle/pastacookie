using UnityEngine;
using System.Collections;

public class ScanFind : MonoBehaviour {

	public GameObject sunArrowPrefab;
	public GameObject planetArrowPrefab;
	public GameObject enemyArrowPrefab;
	public GameObject resourceArrowPrefab;
	public int called;



	// Use this for initialization
	void Start () {
		called = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Space)) {
			Scan ();
			called++;
		}
	}

	GameObject FindClosestEnemy() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	GameObject FindClosestResource() {
		GameObject[] energy;
		energy = GameObject.FindGameObjectsWithTag("energy");
		GameObject[] scrap;
		scrap = GameObject.FindGameObjectsWithTag("scrap");
		GameObject[] gos = new GameObject[energy.Length + scrap.Length];
		scrap.CopyTo (gos, 0);
		energy.CopyTo (gos, scrap.Length);
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	GameObject FindClosestPlanet() {
		GameObject[] planet1;
		GameObject[] planet2;
		GameObject[] planet3;
		GameObject[] planet4;
		planet1 = GameObject.FindGameObjectsWithTag("Planet1");
		planet2 = GameObject.FindGameObjectsWithTag("Planet2");
		planet3 = GameObject.FindGameObjectsWithTag("Planet3");
		planet4 = GameObject.FindGameObjectsWithTag("Planet4");
		GameObject[] gos = new GameObject[planet1.Length + planet2.Length + planet3.Length + planet4.Length];
		planet1.CopyTo (gos, 0);
		planet2.CopyTo (gos, planet1.Length);
		planet3.CopyTo (gos, planet1.Length + planet2.Length);
		planet4.CopyTo (gos, planet1.Length + planet2.Length + planet3.Length);

		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	GameObject FindSun() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Sun");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	void Scan ()
	{
		GameObject closeEnemy = FindClosestEnemy ();
		GameObject closeResource = FindClosestResource ();
		GameObject closePlanet = FindClosestPlanet ();
		GameObject sun = FindSun ();

		DrawArrows (closeEnemy, closeResource, closePlanet, sun);
	}

	void DrawArrows(GameObject closeEnemy, GameObject closeResource, GameObject closePlanet, GameObject sun)
	{
		Vector3 local = this.transform.position;
		if (closeEnemy != null) {
			GameObject enemyArrow = (GameObject)Instantiate(enemyArrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
			enemyArrow.GetComponent<ArrowPoint> ().target = closeEnemy;
			enemyArrow.GetComponent<ArrowPoint> ().playerShip = this.gameObject;
			Destroy (enemyArrow, 5f);
		}
		if (closeResource != null) {
			GameObject resourceArrow = (GameObject)Instantiate(resourceArrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
			resourceArrow.GetComponent<ArrowPoint> ().target = closeResource;
			resourceArrow.GetComponent<ArrowPoint> ().playerShip = this.gameObject;
			Destroy (resourceArrow, 5f);
		}
		if (closePlanet != null) {
			GameObject planetArrow = (GameObject)Instantiate(planetArrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
			planetArrow.GetComponent<ArrowPoint> ().target = closePlanet;
			planetArrow.GetComponent<ArrowPoint> ().playerShip = this.gameObject;
			Destroy (planetArrow, 5f);
		}
		if (sun != null) {
			GameObject sunArrow = (GameObject)Instantiate (sunArrowPrefab, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			sunArrow.GetComponent<ArrowPoint> ().target = sun;
			sunArrow.GetComponent<ArrowPoint> ().playerShip = this.gameObject;
			Destroy (sunArrow, 5f);
		}

	}
}
