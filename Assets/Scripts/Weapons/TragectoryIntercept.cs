using UnityEngine;
using System.Collections;

public class TragectoryIntercept : MonoBehaviour {

	public GameObject origin;
	public GameObject target;
	public Vector3 aimLoc;
	private Vector3 prevLoc;
	public Vector3 currentVelocity;
	public  int bulletVelocity;


	// Use this for initialization
	void Start () {

		origin = this.gameObject;
		prevLoc = target.transform.position;
		currentVelocity = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		if (!target) {
			return;
		}
		Vector3 originPosition = origin.transform.position;
		Vector3 targetPosition = target.transform.position;
		Vector3 directionToFrom = originPosition - targetPosition;

		currentVelocity = (target.transform.position - prevLoc) / Time.deltaTime;
		prevLoc = target.transform.position;

		float timeToImpact = target.GetComponent<Rigidbody2D> ().velocity.magnitude / bulletVelocity;

		aimLoc = targetPosition + currentVelocity * timeToImpact;
	}

}
