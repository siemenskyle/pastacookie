using UnityEngine;
using System.Collections;

public class WeaponSelectUI : MonoBehaviour {

	public PlayerManagement player;
	public Texture2D missileSelected;
	public Texture2D turretSelected;
	public Texture2D laserSelected;

	void Start()
	{
	}
	// Update is called once per frame
	void FixedUpdate () {
		switchWeapons();
	}

	public void switchWeapons()
	{
		switch (player.getWeaponType()) {
		case PlayerManagement.WeaponType.MISSILES:
			GetComponent<GUITexture>().texture = missileSelected;
			break;
		case PlayerManagement.WeaponType.TURRET:
			GetComponent<GUITexture>().texture = turretSelected;
			break;
		case PlayerManagement.WeaponType.LASERS:
			GetComponent<GUITexture> ().texture = laserSelected;
			break;
		}
	}
}
