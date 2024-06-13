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

	IEnumerator OnLookAtHotspotWindow( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("Can't see much...");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotWindow( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("Can't see much...");
		yield return E.Break;
	}

	IEnumerator OnUseInvHotspotWindow( IHotspot hotspot, IInventory item )
	{
		if(item == I.Rubble)
		{
			Prop("BrokenWindow").Visible = true;
			Prop("Glass").Visible = true;
			Prop("Glass").Clickable = true;
		
			I.Rubble.Active = false;
			C.Shapes.RemoveInventory("Rubble");
			yield return C.Display("Lost Rubble");
		
			yield return C.Shapes.Say("Whoops!");
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtPropGlass( IProp prop )
	{
		yield return C.Shapes.Say("Doesn't look too sharp.");
		yield return E.Break;
	}

	IEnumerator OnInteractPropGlass( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Display("Got Glass");
		C.Shapes.AddInventory("Glass");
		Prop("Glass").Disable();
		yield return E.Break;
	}
}