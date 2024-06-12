using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomCliff : RoomScript<RoomCliff>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Fork)
		{
			C.Player.Position = R.Current.GetHotspot("Fork").WalkToPoint;
		}
		else if(R.Previous == R.Ladder)
		{
			C.Player.Position = R.Current.GetHotspot("Ladder").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotLadder( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Ladder;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotFork( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Fork;
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotRupturedEarth( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say(" Looks like the world exploded.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotRobe( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("Someone took this off in a hurry.");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotRobe( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Display("Got Dormant Soul");
		C.Shapes.AddInventory("DormantSoul");
		Hotspot("Robe").Disable();
		yield return E.Break;
	}
}