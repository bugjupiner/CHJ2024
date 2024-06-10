using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomFork : RoomScript<RoomFork>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Basement)
		{
			C.Player.Position = R.Current.GetHotspot("Basement").WalkToPoint;
		}
		else if(R.Previous == R.Storeroom)
		{
			C.Player.Position = R.Current.GetHotspot("Storeroom").WalkToPoint;
		}
		else if(R.Previous == R.Cliff)
		{
			C.Player.Position = R.Current.GetHotspot("Cliff").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotCliff( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Cliff;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotStoreroom( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Storeroom;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotBasement( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Basement;
		yield return E.Break;
	}
}