using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	TragectoryIntercept predictionScript;
	Enemymove enemyMoveScript;
	public GameObject bulletPrefab;
	public int bulletVelocity;
	public float cooldownTimer;
	public int enemyDamage;

	// Use this for initialization
	void Start () {
		bulletVelocity = 8;
		predictionScript = gameObject.GetComponent<TragectoryIntercept>();
		predictionScript.bulletVelocity = bulletVelocity;
		cooldownTimer = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!enemyMoveScript) {
			enemyMoveScript = gameObject.GetComponent<Enemymove> ();
		}
		if (cooldownTimer < Time.time && Vector3.Distance (gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= enemyMoveScript.effectiveRange) {
			cooldownTimer = Time.time + 3f;
			attack ();
		}
	}

	public void attack() {
		GameObject spawnedBullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
		BulletScript newBulletScript = spawnedBullet.GetComponent<BulletScript> ();
		newBulletScript.target = "Player";
		Vector2 targetFutureLocation = predictionScript.calculateTrajectoryToTarget (GameObject.FindGameObjectWithTag("Player"));
		newBulletScript.setDamage (enemyDamage);
		spawnedBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2(targetFutureLocation.x - gameObject.transform.position.x, targetFutureLocation.y - gameObject.transform.position.y).normalized * bulletVelocity;
		DestroyObject (spawnedBullet, 10f);
	}

}
