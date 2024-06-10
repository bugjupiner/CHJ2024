using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomCloisterStart : RoomScript<RoomCloisterStart>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Entryway)
		{
			C.Player.Position = R.Current.GetHotspot("Entryway").WalkToPoint;
		}
		else if(R.Previous == R.Cloister)
		{
			if(Globals.onCloisterGrass) C.Player.Position = R.Current.GetHotspot("CloisterGrass").WalkToPoint;
			else C.Player.Position = R.Current.GetHotspot("CloisterStone").WalkToPoint;
		}
		else if(R.Previous == R.Pathway)
		{
			C.Player.Position = R.Current.GetHotspot("Pathway").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotCloisterGrass( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = true;
		C.Player.Room = R.Cloister;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotPathway( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Pathway;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStone( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = false;
		C.Player.Room = R.Cloister;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotEntryway( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(Globals.jumbled) C.Player.Room = R.Entryway;
		yield return E.Break;
	}
}