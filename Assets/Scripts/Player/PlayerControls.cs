using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	PlayerTurret turretScript;
	string[] weaponsList;
	string selectedWeapon;

	// Use this for initialization
	void Start () {
		weaponsList = new string[1];
		weaponsList[0] = "turret";
		selectedWeapon = "turret";
		turretScript = gameObject.GetComponent<PlayerTurret> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		checkFireWeapons ();

	}

	void checkFireWeapons() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			fireWeapon ();
		}
	}

	void fireWeapon() {
		switch (selectedWeapon) {
		case "turret":
			turretScript.shoot ();
			break;
		}
	}
}
