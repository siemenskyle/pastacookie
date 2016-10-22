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

	int alterAmmo(int change){
		if (ammo + change > 0) {
			ammo += change;
			return ammo;
		}
		return ammo;
	}

	int alterEnergy(int change){
		if (energy + change > 0) {
			energy += change;
			return energy;
		}
		return energy;
	}

	int alterScrap(int change){
		if (scrap + change > 0) {
			scrap += change;
			return scrap;
		}
		return scrap;
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
