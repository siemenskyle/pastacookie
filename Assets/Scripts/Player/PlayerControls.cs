using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	PlayerManagement player;
	PlayerMissile missileScript;
	PlayerTurret turretScript;
	string[] weaponsList;
	PlayerManagement.WeaponType weapontype;
	int selectedWeaponIndex;
	float missileCooldown;
	float missileOnCooldownUntil;
	float turretCooldown;
	float turretOnCooldownUntil;

	int turretCost;
	int missileCost;

	// Use this for initialization
	void Start () {
		turretScript = gameObject.GetComponent<PlayerTurret> ();
		missileScript = gameObject.GetComponent<PlayerMissile> ();
		player = gameObject.GetComponent<PlayerManagement> ();
		missileCooldown = 3f;
		missileOnCooldownUntil = Time.time;
		turretCooldown = 0.2f;
		turretOnCooldownUntil = Time.time;
		missileCost = 5;
		turretCost = 1;
		weapontype = PlayerManagement.WeaponType.TURRET;
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
		if (weapontype == PlayerManagement.WeaponType.TURRET) {
			weapontype = PlayerManagement.WeaponType.MISSILES;
		} else if (weapontype == PlayerManagement.WeaponType.MISSILES) {
			weapontype = PlayerManagement.WeaponType.TURRET;
		}
		player.setWeaponType (weapontype);
	}

	void fireWeapon() {
		switch (weapontype) {
		case PlayerManagement.WeaponType.TURRET:
			if (player.getAmmo () >= turretCost) {
				if (turretOnCooldownUntil < Time.time) {
					turretScript.shoot ();
					turretOnCooldownUntil = Time.time + turretCooldown;
					player.alterAmmo (-turretCost);
				}
			}
			break;
		case PlayerManagement.WeaponType.MISSILES:
			if (player.getAmmo () >= missileCost) {
				if (missileOnCooldownUntil < Time.time) {
					missileScript.shoot ();
					missileOnCooldownUntil = Time.time + missileCooldown;
					player.alterAmmo (-(missileCost));
				}
			}
			break;
		}
	}
}
