using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomYard : RoomScript<RoomYard>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Ladder)
		{
			C.Player.Position = R.Current.GetHotspot("Ladder").WalkToPoint;
		}
		else if(R.Previous == R.Kitchen)
		{
			C.Player.Position = R.Current.GetHotspot("Kitchen").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotKitchen( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Kitchen;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotLadder( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Ladder;
		yield return E.Break;
	}

	IEnumerator OnLookAtPropSpellBubble( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("Hm...");
		yield return E.WaitSkip();
		yield return C.Shapes.Say("It's magic!");
		yield return E.Break;
	}

	IEnumerator OnInteractPropSpellBubble( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Display("Nothing happens.");
		yield return E.Break;
	}

	IEnumerator OnInteractPropSpellbook( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Display("Got Spellbook Volume One");
		C.Shapes.AddInventory("SpellbookOne");
		Prop("Spellbook").Disable();
		yield return E.Break;
	}

	IEnumerator OnLookAtPropSpellbook( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("Sure hope I can read.");
		yield return E.Break;
	}
}