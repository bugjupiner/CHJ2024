using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomCloister : RoomScript<RoomCloister>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Stairwell)
		{
			C.Player.Position = R.Current.GetHotspot("Stairwell").WalkToPoint;
		}
		else if(Globals.onCloisterGrass)
		{
			if(R.Previous == R.CloisterStart) C.Player.Position = R.Current.GetHotspot("CloisterStartGrass").WalkToPoint;
			if(R.Previous == R.CloisterEnd) C.Player.Position = R.Current.GetHotspot("CloisterEndGrass").WalkToPoint;
		}
		else
		{
			if(R.Previous == R.CloisterStart) C.Player.Position = R.Current.GetHotspot("CloisterStartStone").WalkToPoint;
			if(R.Previous == R.CloisterEnd) C.Player.Position = R.Current.GetHotspot("CloisterEndStone").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotStairwell( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Stairwell;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterEndStone( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = false;
		C.Player.Room = R.CloisterEnd;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStartStone( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = false;
		C.Player.Room = R.CloisterStart;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterEndGrass( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = true;
		C.Player.Room = R.CloisterEnd;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStartGrass( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = true;
		C.Player.Room = R.CloisterStart;
		yield return E.Break;
	}
}