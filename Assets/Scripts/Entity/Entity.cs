using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public int health;
	public int maxHealth;
	public int shields;
	public int maxShields;
	public GameObject explode;
	// Use this for initialization
	void Start () {
		
		Debug.Log (explode);
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			//GameObject ex = (GameObject) Object.Instantiate (explode, transform);
			Destroy (gameObject);
		}
	}

	void kill(){
		
		Destroy (gameObject);
	}

	public int alterHealth(int change){
		health += change;
		return health;
	}
}
