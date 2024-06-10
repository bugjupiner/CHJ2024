using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomFront : RoomScript<RoomFront>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Dorm)
		{
			C.Player.Position = R.Current.GetHotspot("Dorm").WalkToPoint;
		}
		else if(R.Previous == R.Entryway)
		{
			C.Player.Position = R.Current.GetHotspot("Entryway").WalkToPoint;
		}
		else if(R.Previous == R.Landing)
		{
			C.Player.Position = R.Current.GetHotspot("Landing").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotLanding( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Landing;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotEntryway( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Entryway;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotDorm( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Dorm;
		yield return E.Break;
	}
}