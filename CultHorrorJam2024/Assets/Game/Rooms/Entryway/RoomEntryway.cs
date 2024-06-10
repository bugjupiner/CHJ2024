using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomEntryway : RoomScript<RoomEntryway>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Front)
		{
			C.Player.Position = R.Current.GetHotspot("Front").WalkToPoint;
		}
		else if(R.Previous == R.CloisterStart)
		{
			C.Player.Position = R.Current.GetHotspot("CloisterStart").WalkToPoint;
		}
		else if(R.Previous == R.Bedroom)
		{
			C.Player.Position = R.Current.GetHotspot("Bedroom").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotBedroom( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Bedroom;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStart( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.CloisterStart;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotFront( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Front;
		yield return E.Break;
	}
}