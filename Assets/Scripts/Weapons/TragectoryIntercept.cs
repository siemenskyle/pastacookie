using UnityEngine;
using System.Collections;

public class TragectoryIntercept : MonoBehaviour {

	public GameObject origin;
	public Vector2 aimLoc;
	private Vector3 prevLoc;
	public Vector3 currentVelocity;
	public  int bulletVelocity;


	// Use this for initialization
	void Start () {
		origin = this.gameObject;
		currentVelocity = Vector3.zero;
	}

	public Vector2 calculateTrajectoryToTarget(GameObject target) {
		Vector3 originPosition = gameObject.transform.position;
		Vector3 targetPosition = target.transform.position;
		Vector3 directionToFrom = originPosition - targetPosition;

		float distanceToTarget = Vector3.Distance (gameObject.transform.position, directionToFrom);

		float timeToImpact = distanceToTarget / bulletVelocity;

		aimLoc = new Vector2(targetPosition.x, targetPosition.y) + (target.GetComponent<Rigidbody2D>().velocity * Time.fixedDeltaTime) * timeToImpact;
		return aimLoc;
	}

}
