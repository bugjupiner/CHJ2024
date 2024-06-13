using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomHiddenRoom : RoomScript<RoomHiddenRoom>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Kitchen)
		{
			C.Player.Position = R.Current.GetHotspot("Kitchen").WalkToPoint;
		}
		
		if(Globals.mirrorScrollFree)
		{
			Prop("MirrorScroll").Clickable = true;
			Prop("AngelBubble").Disable();
		}
	}

	IEnumerator OnInteractHotspotKitchen( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Kitchen;
		yield return E.Break;
	}

	IEnumerator OnLookAtPropAngelBubble( IProp prop )
	{
		yield return C.Shapes.Say("Special kind of magic...");
		yield return E.Break;
	}

	IEnumerator OnInteractPropAngelBubble( IProp prop )
	{
		yield return C.Shapes.Say("Special kind of magic...");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropMirrorScroll( IProp prop )
	{
		yield return C.Shapes.Say("Wow... what is that?");
		yield return E.Break;
	}

	IEnumerator OnInteractPropMirrorScroll( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Display("Got Mirror Scroll");
		C.Shapes.AddInventory("Mirror Scroll");
		Prop("MirrorScroll").Disable();
		
		yield return E.Break;
	}
}