using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomStairwell : RoomScript<RoomStairwell>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Cloister)
		{
			C.Player.Position = R.Current.GetHotspot("Cloister").WalkToPoint;
		}
		else if(R.Previous == R.Basement)
		{
			C.Player.Position = R.Current.GetHotspot("Basement").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotBasement( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.basementDoorOpened = true;
		C.Player.Room = R.Basement;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloister( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Cloister;
		yield return E.Break;
	}
}