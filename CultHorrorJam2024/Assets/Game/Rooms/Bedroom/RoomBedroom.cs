using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomBedroom : RoomScript<RoomBedroom>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Entryway)
		{
			C.Player.Position = R.Current.GetHotspot("Entryway").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotEntryway( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Entryway;
		yield return E.Break;
	}

	IEnumerator OnLookAtPropDiary( IProp prop )
	{
		yield return C.Shapes.Say("It's a diary...");
		yield return C.Shapes.Say(" 'Casina' is written on the cover.");
		yield return E.Break;
	}

	IEnumerator OnInteractPropDiary( IProp prop )
	{
		yield return C.Shapes.Say("This is the High Witch's Diary!");
		yield return E.WaitSkip();
		yield return C.Shapes.Say("There's an entry from yesterday:");
		yield return E.WaitSkip();
		yield return C.Shapes.Say("With the hearth in order and sacrifices secure...");
		yield return C.Shapes.Say("... Everything is ready to go wrong.");
		yield return E.WaitSkip();
		yield return C.Shapes.Say("Vesta won't accept her new home so easily.");
		yield return C.Shapes.Say("It's likely I'll have to pack up and leave first.");
		yield return E.WaitSkip();
		yield return C.Shapes.Say("If that's the case, perhaps I should prepare...");
		yield return E.WaitSkip();
		yield return C.Shapes.Say("That's all she wrote.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotMirrorConception( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Don't see much...");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotMirrorConception( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Don't see much...");
		yield return E.Break;
	}

	IEnumerator OnUseInvHotspotMirrorConception( IHotspot hotspot, IInventory item )
	{
		if(Globals.fireglassActive)
		{
			yield return C.WalkToClicked();
			if(item == I.Conception)
			{
				if(Globals.conceptionSense == senses.See)
				{
					Globals.sensesSatisfied += 1;
					yield return C.Shapes.Say("It liked that!");
					Hotspot("MirrorConception").Disable();
				}
				else
				{
					yield return C.Shapes.Say("Not quite...");
				}
			}
		}
		yield return E.Break;
	}
}