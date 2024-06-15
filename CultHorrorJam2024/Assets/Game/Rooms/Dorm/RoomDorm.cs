using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomDorm : RoomScript<RoomDorm>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Kitchen)
		{
			C.Player.Position = R.Current.GetHotspot("Kitchen").WalkToPoint;
		}
		else if(R.Previous == R.Front)
		{
			C.Player.Position = R.Current.GetHotspot("Front").WalkToPoint;
		}
		else if(R.Previous == R.CloisterEnd)
		{
			C.Player.Position = R.Current.GetProp("PortalCloister").WalkToPoint;
		}
		else if(R.Previous == R.Basement)
		{
			C.Player.Position = R.Current.GetProp("PortalBasement").WalkToPoint;
		}
		else if(R.Previous == R.Storeroom)
		{
			C.Player.Position = R.Current.GetProp("PortalStoreroom").WalkToPoint;
		}
		else if(R.Previous == R.Cliff)
		{
			C.Player.Position = R.Current.GetProp("PortalCliff").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotFront( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Front;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotKitchen( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Kitchen;
		yield return E.Break;
	}

	IEnumerator OnLookAtPropBlanket( IProp prop )
	{
		yield return C.Shapes.Say("Four beds, one blanket?");
		yield return E.Break;
	}

	IEnumerator OnInteractPropBlanket( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("blanket_pickup");
		yield return C.Display("Got Blanket");
		C.Shapes.AddInventory("Blanket");
		Prop("Blanket").Disable();
		yield return E.Break;
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		if(C.Shapes.HasInventory("FacelessSoul"))
		{
			C.Shapes.RemoveInventory("FacelessSoul");
			Audio.Play("faceless_soul_lost");
			yield return C.Display("Lost Faceless Soul;");
		
			yield return C.Shapes.Say("That thing just flew away from me!");
		
			E.FadeColor = Color.white;
			yield return E.FadeOut();
			C.Ghost.Enable();
			E.FadeColor = Color.white;
			yield return E.FadeIn();
		}
		else if(C.Shapes.HasInventory("LonelySoul"))
		{
			C.Shapes.RemoveInventory("LonelySoul");
			Audio.Play("faceless_soul_lost");
			yield return C.Display("Lost Lonely Soul;");
		
			yield return C.Shapes.Say("Where'd that thing go?");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return E.WaitSkip();
		
			Camera.Shake(1f,2f);
			E.FadeColor = Color.white;
			yield return E.FadeOut();
		
			Audio.Play("portal");
			Audio.Play("worm_groan_01");
			Audio.Play("worm_rumble");
		
			Prop("PortalBasement").Enable();
			R.Basement.GetProp("PortalDorm").Enable();
		
			Prop("PortalCliff").Enable();
			R.Cliff.GetProp("PortalDorm").Enable();
		
			Prop("PortalCloister").Enable();
			R.CloisterEnd.GetProp("PortalDorm").Enable();
		
			Prop("PortalStoreroom").Enable();
			R.Storeroom.GetProp("PortalDorm").Enable();
		
			E.FadeColor = Color.white;
			yield return E.FadeIn();
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropPortalCliff( IProp prop )
	{
		yield return C.WalkToClicked();
		if(C.Player.TargetPosition == Prop("PortalCliff").WalkToPoint)
		{
			Audio.Play("portal");
			C.Player.Room = R.Cliff;
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropPortalStoreroom( IProp prop )
	{
		yield return C.WalkToClicked();
		if(C.Player.TargetPosition == Prop("PortalStoreroom").WalkToPoint)
		{
			Audio.Play("portal");
			C.Player.Room = R.Storeroom;
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropPortalBasement( IProp prop )
	{
		yield return C.WalkToClicked();
		if(C.Player.TargetPosition == Prop("PortalBasement").WalkToPoint)
		{
			Audio.Play("portal");
			C.Player.Room = R.Basement;
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropPortalCloister( IProp prop )
	{
		yield return C.WalkToClicked();
		if(C.Player.TargetPosition == Prop("PortalCloister").WalkToPoint)
		{
			Audio.Play("portal");
			C.Player.Room = R.CloisterEnd;
		}
		yield return E.Break;
	}
}