using UnityEngine;
using System.Collections;

public class TragectoryIntercept : MonoBehaviour {

	public GameObject origin;
	public GameObject target;
	public float angle;
	private Vector3 prevLoc;
	public Vector3 currentVelocity;
	public  int bulletVelocity;


	// Use this for initialization
	void Start () {
		origin = this.gameObject;
		prevLoc = origin.transform.position;
		currentVelocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 originPosition = origin.transform.position;
		Vector3 targetPosition = origin.transform.position;
		Vector3 directionToFrom = originPosition - targetPosition;

		currentVelocity = (transform.position - prevLoc) / Time.deltaTime;
		prevLoc = origin.transform.position;

		angle = Vector3.Angle (directionToFrom, currentVelocity);
	}

	float getTargetingAngle(){

		float targetVel = target.GetComponent<Rigidbody2D>().velocity.magnitude;
		float beforeInvSin = targetVel * Mathf.Sin (angle) / bulletVelocity;
		return Mathf.Asin (beforeInvSin) * Mathf.Rad2Deg;

	}
}
