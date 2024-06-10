using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomLadder : RoomScript<RoomLadder>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Cliff)
		{
			C.Player.Position = R.Current.GetHotspot("Cliff").WalkToPoint;
		}
		else if(R.Previous == R.Yard)
		{
			C.Player.Position = R.Current.GetHotspot("Yard").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotCliff( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Cliff;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotYard( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Yard;
		yield return E.Break;
	}
}