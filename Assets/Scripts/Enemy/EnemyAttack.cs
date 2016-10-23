using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	GameObject player;
	TragectoryIntercept predictionScript;
	public int bulletVelocity;

	// Use this for initialization
	void Start () {
		bulletVelocity = 8;
		player = GameObject.FindGameObjectWithTag("Player");
		predictionScript = new TragectoryIntercept ();
		predictionScript.bulletVelocity = bulletVelocity;
		predictionScript.target = player;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
