using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {

	public int turretLevel;
	public int missileLevel;
	public int laserLevel;
	public int thrusterLevel;
	public int hullLevel;

	public int maxLevel;

	int[] missileUpgradeCost;
	int[] turretUpgradeCost;
	int[] laserUpgradeCost;
	int[] thrusterUpgradeCost;
	int[] hullUpgradeCost;

	PlayerMove movement;
	PlayerTurret turret;
	PlayerMissile missile;
	LaserScript laser;
	PlayerManagement player;

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
		if (turretLevel == 3)
			return;
		if (player.getScrap() > turretUpgradeCost [turretLevel]) {
		}
	}

	void upgradeMissile()
	{
		
	}

	void upgradeLaser()
	{

	}

	void upgradeMovement()
	{
		
	}

	void upgradeHull()
	{
		
	}
}
