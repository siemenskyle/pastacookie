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
	float[] BoostLevelStrength;
	int[] hullLevelStrength;

	public PlayerMove movement;
	public PlayerTurret turret;
	public PlayerMissile missile;
	public LaserScript laser;
	public PlayerManagement player;
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
		thrusterLevelStrength = new int[4]{4, 6, 8, 10};
		BoostLevelStrength = new float[4]{3.0f, 3.5f, 4.0f, 5.0f};
		hullLevelStrength = new int[4]{3, 4, 6, 10};

		movement = gameObject.GetComponent<PlayerMove> ();
		turret = gameObject.GetComponent<PlayerTurret> ();
		missile = gameObject.GetComponent<PlayerMissile> ();
		laser = gameObject.GetComponent<LaserScript> ();
		player = gameObject.GetComponent<PlayerManagement> ();
		playerControls = gameObject.GetComponent<PlayerControls> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown ("1")) {
			upgradeTurret ();
		}
		if (Input.GetKeyDown ("2")) {
			upgradeMissile ();
		}
		if (Input.GetKeyDown ("3")) {
			upgradeLaser ();
		}
		if (Input.GetKeyDown ("5")) {
			upgradeMovement ();
		}
		if (Input.GetKeyDown ("4")) {
			upgradeHull ();
		}
	}

	void upgradeTurret()
	{
		if (turretLevel == maxLevel)
			return;
		if (player.getScrap() >= turretUpgradeCost [turretLevel]) {
			player.alterScrap (-turretUpgradeCost[turretLevel]); // cost matrix is from 0-2 so, yes, this is in the right place; before the increment
			turretLevel += 1;
			playerControls.setTurretDamage (turretLevelStrength [turretLevel]);
		}
	}

	void upgradeMissile()
	{
		if (missileLevel == maxLevel)
			return;
		if (player.getScrap() >= missileUpgradeCost [missileLevel]) {
			player.alterScrap (-missileUpgradeCost[missileLevel]);
			missileLevel += 1;
			playerControls.setMissileDamage (missileLevelStrength [missileLevel]);
		}
	}

	void upgradeLaser()
	{
		if (laserLevel == maxLevel)
			return;
		if (player.getScrap() >= laserUpgradeCost [laserLevel]) {
			player.alterScrap (-laserUpgradeCost[laserLevel]);
			laserLevel += 1;
			playerControls.setLaserDamage (laserLevelStrength [laserLevel]);
		}
	}

	void upgradeMovement()
	{
		if (thrusterLevel == maxLevel)
			return;
		if (player.getScrap() >= thrusterUpgradeCost [thrusterLevel]) {
			player.alterScrap (-thrusterUpgradeCost[thrusterLevel]);
			thrusterLevel += 1;
			movement.speed = thrusterLevelStrength [thrusterLevel];
			movement.boostMult = BoostLevelStrength [thrusterLevel];
		}
	}

	void upgradeHull()
	{
		if (hullLevel == maxLevel)
			return;
		if (player.getScrap() >= hullUpgradeCost [hullLevel]) {
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
		playerControls.setLaserDamage(laserLevelStrength [0]);
	}
	public void setThrusterStartStat()
	{
		movement.speed = thrusterLevelStrength [0];
		movement.boostMult = BoostLevelStrength [0];
	}
	public void setHullStartStat()
	{
		Debug.Log (hullLevelStrength [0]);
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
