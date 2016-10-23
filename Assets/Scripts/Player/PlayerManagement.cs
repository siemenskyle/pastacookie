using UnityEngine;
using System.Collections;

public class PlayerManagement : Entity 
{
	public enum Resource {AMMO, ENERGY, SCRAP};
	public enum WeaponType {TURRET, MISSILES, LASERS};
	// Use this for initialization
	public int scrap;
	public int energy;
	public int ammo;
	public WeaponType weaponType;

	Upgrades upgrades;

	void Start ()
	{
		alterAmmo(StartingStats.getStartingAmmo());
		alterEnergy(StartingStats.getStartingEnergy());
		alterScrap(StartingStats.getStartingScrap());
		upgrades = gameObject.GetComponent<Upgrades> ();
		upgrades.setAllStartUpgrades ();
		health = maxHealth;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
		
	public int alterAmmo(int change){
		if (ammo + change >= 0) {
			ammo += change;
		}
		return ammo;
	}

	public int alterEnergy(int change){
		if (energy + change >= 0) {
			energy += change;
		}
		return energy;
	}

	public void setWeaponType(WeaponType type)
	{
		weaponType = type;
	}

	public WeaponType getWeaponType()
	{
		return weaponType;
	}

	public int alterScrap(int change){
		if (scrap + change >= 0) {
			scrap += change;
		}
		return scrap;
	}

	public int getAmmo(){
		return ammo;
	}

	public int getEnergy(){
		return energy;
	}

	public int getScrap(){
		return scrap;
	}

	public int getMaxHull(){
		return maxHealth;
	}
	public int getCurrentHull(){
		return health;
	}

	public void setMaxHull(int hull)
	{
		maxHealth = hull;
	}

	/// <summary>
	/// pass it a negative value for damage
	/// </summary>
	/// <param name="repair">Repair.</param>
	public void repairDamageHull(int amount){
		health += amount;
		if (health > maxHealth)
			health = maxHealth;
	}


}
