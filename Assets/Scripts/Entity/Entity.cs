﻿using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public int health;
	public int maxHealth;
	public int shields;
	public int maxShields;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public int alterHealth(int change){
		health += change;
		return health;
	}
}
