using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomPathway : RoomScript<RoomPathway>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.CloisterStart)
		{
			C.Player.Position = R.Current.GetHotspot("CloisterStart").WalkToPoint;
		}
		else if(R.Previous == R.RitualSite)
		{
			C.Player.Position = R.Current.GetHotspot("RitualSite").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotRitualSite( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.RitualSite;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStart( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.CloisterStart;
		yield return E.Break;
	}
}