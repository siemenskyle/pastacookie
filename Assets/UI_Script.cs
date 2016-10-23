using UnityEngine;
using System.Collections;

public class UI_Script : MonoBehaviour {

	public GUIText energyText;
	public GUIText scrapText;
	public GUIText ammoText;
	public GUIText healthText;
	public GUIText turretLevel;
	public GUIText missileLevel;
	public GUIText laserLevel;
	public GUIText hullLevel;
	public GUIText thrustersLevel;
	public GUIText gravWarning;
	public PlayerManagement playerData;
	public Upgrades upgrade;
	public PlanetScript gravity;

	private int damageDur;

	// Use this for initialization
	void Start () {
		setHud();
	}

	// Update is called once per frame
	void FixedUpdate () {
		setHud();
	}

	private void setHud()
	{
		energyText.text = playerData.getEnergy ().ToString();
		scrapText.text = playerData.getScrap ().ToString();
		ammoText.text = playerData.getAmmo ().ToString();
		healthText.text = playerData.getCurrentHull ().ToString ();
		turretLevel.text = upgrade.turretLevel.ToString ();
		missileLevel.text = upgrade.missileLevel.ToString ();
		laserLevel.text = upgrade.laserLevel.ToString ();
		hullLevel.text = upgrade.hullLevel.ToString ();
		thrustersLevel.text = upgrade.thrusterLevel.ToString ();
		//Debug.Log ("9");
		//gravWarning.enabled = gravity.inGravityWell;
		//Debug.Log (gravity.inGravityWell);
	}

}
