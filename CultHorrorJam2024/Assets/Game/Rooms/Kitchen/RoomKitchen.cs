using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomKitchen : RoomScript<RoomKitchen>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Yard)
		{
			C.Player.Position = R.Current.GetHotspot("Yard").WalkToPoint;
		}
		else if(R.Previous == R.Dorm)
		{
			C.Player.Position = R.Current.GetHotspot("Dorm").WalkToPoint;
		}
		else if(R.Previous == R.HiddenRoom)
		{
			C.Player.Position = R.Current.GetHotspot("HiddenRoom").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotHiddenRoom( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.HiddenRoom;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotDorm( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Dorm;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotYard( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Yard;
		yield return E.Break;
	}
}