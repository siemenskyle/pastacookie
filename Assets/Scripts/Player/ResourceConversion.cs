using UnityEngine;
using System.Collections;

public class ResourceConversion : MonoBehaviour {

	private GameObject player;
	private PlayerManagement playerMan;

	// Use this for initialization
	void Start () {
		player = this.gameObject;
		playerMan = player.GetComponent<PlayerManagement> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Z)) {
			scrapToEnergy ();
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			scrapToAmmo ();
		}
	
	}

	void scrapToEnergy()
	{
		if (playerMan.getScrap () > 0) {
			playerMan.alterScrap (-1);
			playerMan.alterEnergy (5);
		}
	}

	void scrapToAmmo ()
	{
		if (playerMan.getScrap () > 0) {
			playerMan.alterScrap (-1);
			playerMan.alterAmmo (5);
		}
	}
}
