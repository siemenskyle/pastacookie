using UnityEngine;
using System.Collections;

public static class StartingStats : object {

	private static int startingAmmo = 10;
	private static int startingScrap = 10;
	private static int startingEnergy = 10;
	private static int startingHealth = 10;

	public static int getStartingAmmo()
	{
		return startingAmmo;
	}
	public static int getStartingScrap()
	{
		return startingScrap;
	}
	public static int getStartingHealth()
	{
		return startingHealth;
	}
	public static int getStartingEnergy()
	{
		return startingEnergy;
	}
}
