using UnityEngine;
using System.Collections;

public class UI_Script : MonoBehaviour {

	public GUIText energyText;
	public GUIText scrapText;
	public GUIText ammoText;
	public GUIText healthText;
	public PlayerManagement playerData;

	private int damageDur;

	// Use this for initialization
	void Start () {
		setHud();
	}

	// Update is called once per frame
	void Update () {
		setHud();
	}

	private void setHud()
	{
		energyText.text = playerData.getEnergy ().ToString();
		scrapText.text = playerData.getScrap ().ToString();
		ammoText.text = playerData.getAmmo ().ToString();
		healthText.text = playerData.getCurrentHull ().ToString ();
	}

}
