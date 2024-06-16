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

	IEnumerator OnLookAtPropPamphlet( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("This has that strange symbol...");
		yield return E.Break;
	}

	IEnumerator OnInteractPropPamphlet( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("pamphlet_pickup");
		yield return C.Display("Got Pamphlet");
		Prop("Pamphlet").Disable();
		C.Shapes.AddInventory("Pamphlet");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotCliff( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Back to the cliff.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotYard( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Light!");
		yield return E.Break;
	}
}