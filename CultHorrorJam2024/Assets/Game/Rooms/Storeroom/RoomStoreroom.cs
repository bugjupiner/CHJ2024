using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomStoreroom : RoomScript<RoomStoreroom>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Fork)
		{
			C.Player.Position = R.Current.GetHotspot("Fork").WalkToPoint;
		}
		else if(R.Previous == R.Cells)
		{
			C.Player.Position = R.Current.GetPoint("Cells");
		}
		else if(R.Previous == R.Dorm)
		{
			C.Player.Position = R.Current.GetProp("PortalDorm").WalkToPoint;
		}
		
		if(C.Worm.Visible) Audio.Play("worm_groan_03");
	}

	IEnumerator OnInteractHotspotFork( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Fork;
		yield return E.Break;
	}

	IEnumerator OnInteractPropDollHead( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("doll_head_pickup");
		yield return C.Display("Got Doll Head");
		C.Shapes.AddInventory("DollHead");
		Prop("DollHead").Disable();
		yield return E.Break;
	}

	IEnumerator OnInteractPropPortalDorm( IProp prop )
	{
		yield return C.WalkToClicked();
		Audio.Play("portal");
		C.Player.Room = R.Dorm;
		yield return E.Break;
	}

	IEnumerator OnLookAtPropPortalDorm( IProp prop )
	{
		yield return C.Shapes.Say("It's a portal!");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotRobe( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("dormant_soul_pickup");
		C.Shapes.AddInventory("LonelySoul");
		yield return C.Display("Got Lonely Soul");
		Hotspot("Robe").Disable();
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotRobe( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Another cultist robe...");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotFork( IHotspot hotspot )
	{
		yield return C.Shapes.Say("I should get out of here.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropDollHead( IProp prop )
	{
		yield return C.Shapes.Say("Some part of a doll.");
		yield return E.Break;
	}
}