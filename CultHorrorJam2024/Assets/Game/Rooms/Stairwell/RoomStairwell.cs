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

	IEnumerator OnLookAtPropDollBody( IProp prop )
	{
		yield return C.Shapes.Say("Looks like part of a doll.");
		yield return C.Shapes.Say("Where's the head?");
		yield return E.Break;
	}

	IEnumerator OnInteractPropDollBody( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("doll_body_pickup");
		yield return C.Display("Got Doll Body");
		C.Shapes.AddInventory("DollBody");
		Prop("DollBody").Disable();
		yield return E.Break;
	}

	IEnumerator OnUseInvPropDollBody( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotBasement( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Down I go.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotCloister( IHotspot hotspot )
	{
		yield return C.Shapes.Say("The cloister.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotSpike( IHotspot hotspot )
	{
		yield return C.Shapes.FaceRight();
		yield return C.Shapes.Say("Looks like it's still hot.");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotSpike( IHotspot hotspot )
	{
		yield return C.Shapes.FaceRight();
		yield return C.Shapes.Say("Looks like it's still hot.");
		yield return E.Break;
	}
}