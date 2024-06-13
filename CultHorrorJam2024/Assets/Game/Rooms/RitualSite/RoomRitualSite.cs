using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomRitualSite : RoomScript<RoomRitualSite>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Pathway)
		{
			C.Player.Position = R.Current.GetHotspot("Pathway").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotPathway( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Pathway;
		yield return E.Break;
	}

	IEnumerator OnUseInvPropSmallFire( IProp prop, IInventory item )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.FaceRight();
		
		if(item == I.Doll)
		{
			I.Doll.Active = false;
			C.Shapes.RemoveInventory("Doll");
		
			yield return C.Display("Doll Sacrificed");
			Globals.dollSacrificed = true;
		}
		if(item == I.VirginsBlood)
		{
			I.VirginsBlood.Active = false;
			C.Shapes.RemoveInventory("VirginsBlood");
		
			yield return C.Display("Virgin's Blood Sacrificed");
			Globals.virginBloodSacrificed = true;
		}
		if(Globals.dollSacrificed && Globals.virginBloodSacrificed && !Globals.hearthSummoned)
		{
			Globals.hearthSummoned = true;
		
			Prop("SmallFire").Disable();
			Prop("Fire").Enable();
			yield return C.Shapes.Say("Whoa!");
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropSmallFire( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("It's a little fire.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropSmallFire( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("It's a little fire.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropFire( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("Hot!");
		yield return E.Break;
	}

	IEnumerator OnInteractPropFire( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("Hot!");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropInversionScroll( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		if(!Globals.fireglassActive)
		{
			yield return C.Shapes.Say("Completely Burnt.");
		}
		else
		{
			yield return C.Shapes.Say("It's some kind of scroll!");
		}
		
		yield return E.Break;
	}

	IEnumerator OnInteractPropInversionScroll( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		if(!Globals.fireglassActive)
		{
			yield return C.Shapes.Say("Completely Burnt.");
		}
		else
		{
			yield return C.Display("Got Inversion Scroll");
			C.Shapes.AddInventory("InversionScroll");
		
			Prop("BurntScroll").Disable();
			Prop("InversionScroll").Disable();
		}
		yield return E.Break;
	}
}