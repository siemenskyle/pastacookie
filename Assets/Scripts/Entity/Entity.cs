using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public int health;
	public int shields;

	// Use this for initialization
	void Start () {
		health = StartingStats.getStartingHealth ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public int alterHealth(int change){
		health += change;
		return health;
	}
}
