using UnityEngine;
using System.Collections;

public class ArrowPoint : MonoBehaviour {

	public GameObject target;
	public GameObject playerShip;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		this.transform.LookAt (target.transform.position, Vector3.up);
		this.transform.position = playerShip.transform.position;
		this.transform.position = this.transform.position + this.transform.forward * 3;
		this.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);

		Vector3 moveDirection = gameObject.transform.position - target.transform.position;
		float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
