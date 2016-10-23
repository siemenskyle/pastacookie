using UnityEngine;
using System.Collections;
public class Upgrades : MonoBehaviour {

	public int turretLevel;
	public int missileLevel;
	public int laserLevel;
	public int thrusterLevel;
	public int hullLevel;

	public int maxLevel;

	int[] turretUpgradeCost;
	int[] missileUpgradeCost;
	int[] laserUpgradeCost;
	int[] thrusterUpgradeCost;
	int[] hullUpgradeCost;

	int[] turretLevelStrength;
	int[] missileLevelStrength;
	int[] laserLevelStrength;
	int[] thrusterLevelStrength;
	int[] hullLevelStrength;

	PlayerMove movement;
	PlayerTurret turret;
	PlayerMissile missile;
	LaserScript laser;
	PlayerManagement player;
	PlayerControls playerControls;

	// Use this for initialization
	void Start () {

		turretLevel = 0;
		missileLevel = 0;
		laserLevel = 0;
		thrusterLevel = 0;
		hullLevel = 0;
		maxLevel = 3;

		missileUpgradeCost = new int[3]{3, 4, 5};
		turretUpgradeCost = new int[3]{3, 4, 5};
		laserUpgradeCost = new int[3]{3, 4, 5};
		thrusterUpgradeCost = new int[3]{3, 4, 5};
		hullUpgradeCost = new int[3]{3, 4, 5};

		turretLevelStrength = new int[4]{6, 10, 15, 25};
		missileLevelStrength = new int[4]{30, 40, 60, 100};
		laserLevelStrength = new int[4]{3, 5, 8, 12};
		thrusterLevelStrength = new int[4]{2, 3, 4, 5};
		hullLevelStrength = new int[4]{3, 4, 6, 10};

		movement = gameObject.GetComponent<PlayerMove> ();
		turret = gameObject.GetComponent<PlayerTurret> ();
		missile = gameObject.GetComponent<PlayerMissile> ();
		laser = gameObject.GetComponent<LaserScript> ();
		player = gameObject.GetComponent<PlayerManagement> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown ("1")) {
			upgradeTurret ();
		}
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown ("2")) {
			upgradeMissile ();
		}
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown ("3")) {
			upgradeLaser ();
		}
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown ("4")) {
			upgradeMovement ();
		}
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown ("5")) {
			upgradeHull ();
		}
	}

	void upgradeTurret()
	{
		if (turretLevel == maxLevel)
			return;
		if (player.getScrap() > turretUpgradeCost [turretLevel]) {
			player.alterScrap (-turretUpgradeCost[turretLevel]); // cost matrix is from 0-2 so, yes, this is in the right place; before the increment
			turretLevel += 1;
			playerControls.setTurretDamage (turretLevelStrength [turretLevel]);
		}
	}

	void upgradeMissile()
	{
		if (missileLevel == maxLevel)
			return;
		if (player.getScrap() > missileUpgradeCost [missileLevel]) {
			player.alterScrap (-missileUpgradeCost[missileLevel]);
			missileLevel += 1;
			playerControls.setMissileDamage (missileLevelStrength [missileLevel]);
		}
	}

	void upgradeLaser()
	{
		if (laserLevel == maxLevel)
			return;
		if (player.getScrap() > laserUpgradeCost [laserLevel]) {
			
		}
	}

	void upgradeMovement()
	{
		if (thrusterLevel == maxLevel)
			return;
		if (player.getScrap() > thrusterUpgradeCost [thrusterLevel]) {
			player.alterScrap (-thrusterUpgradeCost[thrusterLevel]);
			thrusterLevel += 1;
			movement.speed = thrusterLevelStrength [thrusterLevel];
		}
	}

	void upgradeHull()
	{
		if (hullLevel == maxLevel)
			return;
		if (player.getScrap() > hullUpgradeCost [hullLevel]) {
			player.alterScrap (-hullUpgradeCost[hullLevel]);
			hullLevel += 1;
			player.setMaxHull(hullLevelStrength [hullLevel]);
		}
	}

	public int getTurretStartStat()
	{
		return turretLevelStrength [0];
	}
	public int getMissileStartStat()
	{
		return missileLevelStrength [0];
	}
	public int getLaserStartStat()
	{
		return laserLevelStrength [0];
	}
	public int getThrusterStartStat()
	{
		return thrusterLevelStrength [0];
	}
	public int getHullStartStat()
	{
		return hullLevelStrength [0];
	}

	public void setTurretStartStat()
	{
		playerControls.setTurretDamage( turretLevelStrength [0]);
	}
	public void setMissileStartStat()
	{
		playerControls.setMissileDamage(missileLevelStrength [0]);
	}
	public void setLaserStartStat()
	{
		// TODO laserLevelStrength [0];
	}
	public void setThrusterStartStat()
	{
		movement.speed = thrusterLevelStrength [0];
	}
	public void setHullStartStat()
	{
		player.setMaxHull(hullLevelStrength [0]);
	}

	public void setAllStartUpgrades()
	{
		setTurretStartStat ();
		setMissileStartStat ();
		setLaserStartStat ();
		setThrusterStartStat ();
		setHullStartStat ();
	}
}
