using UnityEngine;
using System.Collections;

public static class StartingStats : object {

	private static int startingAmmo = 10;
	private static int startingScrap = 10;
	private static int startingEnergy = 10;

	public static int getStartingAmmo()
	{
		return startingAmmo;
	}
	public static int getStartingScrap()
	{
		return startingScrap;
	}
	public static int getStartingEnergy()
	{
		return startingEnergy;
	}
}
