using UnityEngine;
using System.Collections;

public class PlayerResources : MonoBehaviour {

	public int scrap;
	public int energy;
	public int ammo;

	// Use this for initialization
	void Start () {
	
		scrap = 0;
		energy = 0;
		ammo = 0;
	}

	bool alterAmmo(int change){
		if (ammo + change > 0) {
			ammo += change;
			return true;
		}
		return false;
	}

	bool alterEnergy(int change){
		if (energy + change > 0) {
			energy += change;
			return true;
		}
		return false;
	}

	bool alterScrap(int change){
		if (scrap + change > 0) {
			scrap += change;
			return true;
		}
		return false;
	}

	int getAmmo(){
		return ammo;
	}

	int getEnergy(){
		return energy;
	}

	int getScrap(){
		return scrap;
	}
}
