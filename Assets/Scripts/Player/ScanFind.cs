using UnityEngine;
using System.Collections;

public class ScanFind : MonoBehaviour {

	public GameObject sunArrowPrefab;
	public GameObject planetArrowPrefab;
	public GameObject enemyArrowPrefab;
	public GameObject resourceArrowPrefab;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.C)) {
			Scan ();
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
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("resource");
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
		planet1 = GameObject.FindGameObjectsWithTag("planet1");
		planet2 = GameObject.FindGameObjectsWithTag("planet2");
		planet3 = GameObject.FindGameObjectsWithTag("planet3");
		planet4 = GameObject.FindGameObjectsWithTag("planet4");
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
		gos = GameObject.FindGameObjectsWithTag("sun");
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
		Vector3 enemyDirection = closeEnemy.transform.position - local;
		Vector3 resourceDirection = closeResource.transform.position - local;
		Vector3 planetDirection = closePlanet.transform.position - local;
		Vector3 sunDirection = sun.transform.position - local;

		enemyDirection = enemyDirection.normalized * 3;
		resourceDirection = resourceDirection.normalized * 3;
		planetDirection = planetDirection.normalized * 3;
		sunDirection = sunDirection.normalized * 3;

		GameObject enemyArrow = (GameObject)Instantiate(enemyArrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		GameObject resourceArrow = (GameObject)Instantiate(resourceArrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		GameObject planetArrow = (GameObject)Instantiate(planetArrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		GameObject sunArrow = (GameObject)Instantiate(sunArrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

	}
}
