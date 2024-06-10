using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomCloisterEnd : RoomScript<RoomCloisterEnd>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Cloister)
		{
			if(Globals.onCloisterGrass) C.Player.Position = R.Current.GetHotspot("CloisterGrass").WalkToPoint;
			else C.Player.Position = R.Current.GetHotspot("CloisterStone").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotCloisterStone( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = false;
		C.Player.Room = R.Cloister;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterGrass( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = true;
		C.Player.Room = R.Cloister;
		yield return E.Break;
	}
}