using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

	public string scene;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.P))
			Application.LoadLevel (scene);
	}
}
