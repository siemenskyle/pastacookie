using UnityEngine;
using System.Collections;

public class PlayerManagement : Entity 
{
	public enum Resource {AMMO, ENERGY, SCRAP};
	public enum WeaponType {GUNS, MISSILES, LASERS};
	// Use this for initialization
	public int scrap;
	public int energy;
	public int ammo;
	public WeaponType weaponType;

	void Start ()
	{
		health = StartingStats.getStartingHealth ();
		alterAmmo(StartingStats.getStartingAmmo());
		alterEnergy(StartingStats.getStartingEnergy());
		alterScrap(StartingStats.getStartingScrap());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
		
	public int alterAmmo(int change){
		if (ammo + change > 0) {
			ammo += change;
		}
		return ammo;
	}

	public int alterEnergy(int change){
		if (energy + change > 0) {
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
		if (scrap + change > 0) {
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
}
