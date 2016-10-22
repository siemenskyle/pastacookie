using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	PlayerMissile missileScript;
	PlayerTurret turretScript;
	string[] weaponsList;
	int selectedWeaponIndex;

	// Use this for initialization
	void Start () {
		weaponsList = new string[2];
		weaponsList[0] = "turret";
		weaponsList[1] = "missile";
		selectedWeaponIndex = 0;
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
			switchWeapon ();
		}
	}

	void switchWeapon() {
		selectedWeaponIndex += 1;
		if (selectedWeaponIndex >= weaponsList.Length) {
			selectedWeaponIndex = 0;
		}
	}

	void fireWeapon() {
		switch (weaponsList[selectedWeaponIndex]) {
		case "turret":
			turretScript.shoot ();
			break;
		case "missile":
			missileScript.shoot ();
			break;
		}
	}
}
