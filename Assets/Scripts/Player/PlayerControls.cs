using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	PlayerManagement player;
	PlayerMissile missileScript;
	PlayerTurret turretScript;
	LaserScript laserScript;
	string[] weaponsList;
	PlayerManagement.WeaponType weapontype;
	int selectedWeaponIndex;
	float missileCooldown;
	float missileOnCooldownUntil;
	float laserCooldown;
	float laserOnCooldownUntil;
	float turretCooldown;
	float turretOnCooldownUntil;
	public LayerMask laserMask;

	int turretCost;
	int missileCost;
	int laserCost;

	int turretDamage;
	int missileDamage;
	int laserDamage;

	// Use this for initialization
	void Start () {
		turretScript = gameObject.GetComponent<PlayerTurret> ();
		missileScript = gameObject.GetComponent<PlayerMissile> ();
		laserScript = gameObject.GetComponent<LaserScript> ();
		player = gameObject.GetComponent<PlayerManagement> ();
		missileCooldown = 3f;
		missileOnCooldownUntil = Time.time;
		turretCooldown = 0.2f;
		turretOnCooldownUntil = Time.time;
		laserCooldown = 3f;
		laserOnCooldownUntil = Time.time;
		missileCost = 5;
		turretCost = 1;
		laserCost = 1;
		missileDamage = 100;
		turretDamage = 50;
		laserDamage = 100;
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
			weapontype = PlayerManagement.WeaponType.LASERS;
		} else if (weapontype == PlayerManagement.WeaponType.LASERS) {
			weapontype = PlayerManagement.WeaponType.TURRET;
		}
		player.setWeaponType (weapontype);
	}

	void fireWeapon() {
		switch (weapontype) {
		case PlayerManagement.WeaponType.TURRET:
			if (player.getAmmo () >= turretCost) {
				if (turretOnCooldownUntil < Time.time) {
					turretScript.shoot (turretDamage);
					turretOnCooldownUntil = Time.time + turretCooldown;
					player.alterAmmo (-turretCost);
				}
			}
			break;
		case PlayerManagement.WeaponType.MISSILES:
			if (player.getAmmo () >= missileCost) {
				if (missileOnCooldownUntil < Time.time) {
					missileScript.shoot (missileDamage);
					missileOnCooldownUntil = Time.time + missileCooldown;
					player.alterAmmo (-(missileCost));
				}
			}
			break;
		case PlayerManagement.WeaponType.LASERS:
			if (player.getEnergy () >= laserCost) {
				if (laserOnCooldownUntil < Time.time) {
					laserScript.FireLaser (this.gameObject, Input.mousePosition, laserMask, laserDamage);
					laserOnCooldownUntil = Time.time + laserCooldown;
					player.alterEnergy (-(laserCost));
				}
			}
			break;
		}
	}

	public void setTurretDamage(int damage)
	{
		turretDamage = damage;
	}

	public void setMissileDamage(int damage)
	{
		missileDamage = damage;
	}
}
