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
			yield return C.Display("Lost Faceless Soul;");
		
			yield return C.Shapes.Say("That thing just flew away from me!");
		
			E.FadeColor = Color.white;
			yield return E.FadeOut();
			C.Ghost.Enable();
			E.FadeColor = Color.white;
			yield return E.FadeIn();
		}
		yield return E.Break;
	}
}