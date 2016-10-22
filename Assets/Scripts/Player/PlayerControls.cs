using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	PlayerMissile missileScript;
	PlayerTurret turretScript;
	string[] weaponsList;
	string selectedWeapon;

	// Use this for initialization
	void Start () {
		weaponsList = new string[2];
		weaponsList[0] = "turret";
		weaponsList[1] = "missile";
		selectedWeapon = "turret";
		turretScript = gameObject.GetComponent<PlayerTurret> ();
		missileScript = gameObject.GetComponent<PlayerMissile> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		checkFireWeapons ();
		checkSwitchWeapon ();
	}

	void checkFireWeapons() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			fireWeapon ();
		}
	}

	void checkSwitchWeapon() {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			fireWeapon ();
		}
	}

	void switchWeapon() {

	}

	void fireWeapon() {
		switch (selectedWeapon) {
		case "turret":
			turretScript.shoot ();
			break;
		case "missile":
			missileScript.shoot ();
			break;
		}
	}
}
