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
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			//GameObject ex = (GameObject) Object.Instantiate (explode, transform);
			if (this.tag == "Player") {
				GetComponent<Rigidbody2D> ().isKinematic = true;
				GetComponent<SpriteRenderer> ().enabled = false;
			}
			else
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
