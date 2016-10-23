using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	PlayerManagement player;
	PlayerMissile missileScript;
	PlayerTurret turretScript;
	string[] weaponsList;
	int selectedWeaponIndex;
	float missileCooldown;
	float missileOnCooldownUntil;
	float turretCooldown;
	float turretOnCooldownUntil;

	// Use this for initialization
	void Start () {
		weaponsList = new string[2];
		weaponsList[0] = "turret";
		weaponsList[1] = "missile";
		selectedWeaponIndex = 0;
		turretScript = gameObject.GetComponent<PlayerTurret> ();
		missileScript = gameObject.GetComponent<PlayerMissile> ();
		player = gameObject.GetComponent<PlayerManagement> ();
		missileCooldown = 3f;
		missileOnCooldownUntil = Time.time;
		turretCooldown = 3f;
		turretOnCooldownUntil = Time.time;
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
			if (player.getAmmo () > 1) {
				if (turretOnCooldownUntil < Time.time) {
					turretScript.shoot ();
					turretOnCooldownUntil = Time.time + turretCooldown;
				}
				player.alterAmmo (-1);
			}
			break;
		case "missile":
			if (player.getAmmo () > 5) {
				if (missileOnCooldownUntil < Time.time) {
					missileScript.shoot ();
					missileOnCooldownUntil = Time.time + missileCooldown;
				}
				player.alterAmmo (-5);
			}
			break;
		}
	}
}
