using UnityEngine;
using System.Collections;

public class testFireLaser : MonoBehaviour {

	public LayerMask mask;
	public int stuff;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			GetComponent<LaserScript> ().FireLaser (this.gameObject, Input.mousePosition,  mask, 0);
			stuff++;
		}
	}
}
