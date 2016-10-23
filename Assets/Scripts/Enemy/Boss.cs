using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boss : EnemyHealth {

	public float rotationSpeed;
	public float sightRange;
	public GameObject enemyShip;
	public int spawnIntLow;
	public int spawnIntHigh;

	bool battleStart;

	Transform spawn1, spawn2;

	bool spawnWait;
	bool spawnswapper;
	Transform playerLocation;
	float totalhealth;
	SpriteRenderer sprite;
	AudioSource bgm;

	// Use this for initialization
	void Start () {
		playerLocation = GameObject.FindGameObjectWithTag ("Player").transform;
		spawnWait = false;
		spawn1 = GameObject.FindGameObjectsWithTag ("spawn") [0].transform;
		spawn2 = GameObject.FindGameObjectsWithTag ("spawn") [1].transform;
		totalhealth = health;
		sprite = GetComponent<SpriteRenderer> ();
		bgm = GameObject.FindGameObjectWithTag ("Sun").GetComponent<AudioSource> ();
		battleStart = false;
	}
	
	// Update is bad
	void FixedUpdate () {
		transform.Rotate (0, 0, rotationSpeed);

		float distance = Vector3.Distance (transform.position, playerLocation.position);
		if (distance < sightRange && !spawnWait) {
			if (!battleStart) {
				GetComponent<AudioSource> ().Play ();
				battleStart = true;
				bgm.Stop ();
			}
			spawnWait = true;
			Invoke ("SpawnEnemy", Random.Range(spawnIntLow, spawnIntHigh));
		}

		float healthcol = health/totalhealth;
		Debug.Log (sprite.color.r);
		sprite.color = new Color(1, healthcol, healthcol);
	}

	void SpawnEnemy() {
		if(spawnswapper)
			Object.Instantiate (enemyShip, spawn1.position, new Quaternion());
		else
			Object.Instantiate (enemyShip, spawn2.position, new Quaternion());
		spawnswapper = !spawnswapper;
		spawnWait = false;
	}

	void Update () {
		if (health <= 0) {
			sprite.enabled = false;
			Invoke ("win", 2f );
		}
	}

	void win(){
		Application.LoadLevel ("EndScreen");
	}
}