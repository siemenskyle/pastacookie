﻿using UnityEngine;
using System.Collections;

public class killself : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1);
	}
}
