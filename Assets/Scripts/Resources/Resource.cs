using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {

	private int resource = 5;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log (collider.gameObject.tag);
		if (collider.gameObject.tag == "Player") {
			if (gameObject.tag == "energy")
				collider.gameObject.GetComponent<PlayerManagement> ().alterEnergy (resource);
			if (gameObject.tag == "scrap")
				collider.gameObject.GetComponent<PlayerManagement> ().alterScrap (resource);
			this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			this.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
		}
	}
}
