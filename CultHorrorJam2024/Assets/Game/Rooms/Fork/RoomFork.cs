using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomFork : RoomScript<RoomFork>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Basement)
		{
			C.Player.Position = R.Current.GetHotspot("Basement").WalkToPoint;
		}
		else if(R.Previous == R.Storeroom)
		{
			C.Player.Position = R.Current.GetHotspot("Storeroom").WalkToPoint;
		}
		else if(R.Previous == R.Cliff)
		{
			C.Player.Position = R.Current.GetHotspot("Cliff").WalkToPoint;
		}
		
		if(Globals.basementDoorOpened) Prop("BasementDoor").Visible = true;
	}

	IEnumerator OnInteractHotspotCliff( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Cliff;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotStoreroom( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Storeroom;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotBasement( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Basement;
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotSymbol( IHotspot hotspot )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtPropShrine( IProp prop )
	{
		yield return C.Shapes.Say("A worship site coupled with strange symbols.");
		yield return E.WaitSkip();
		yield return C.Shapes.Say("Homey.");
		yield return E.Break;
	}

	IEnumerator OnInteractPropShrine( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("There's writing on the plaque.");
		C.Shapes.TextColour = Color.yellow;
		yield return C.Shapes.Say("Vesta's Myth of Miracle");
		yield return C.Shapes.Say("Virgin Priestess, Behold Her Shape In Fire");
		yield return E.WaitSkip();
		yield return C.Shapes.Say("Feel Her Heat Hrom Hearth, And Conceive");
		yield return C.Shapes.Say("A Miraculous Conception With Senses of a God");
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		C.Shapes.TextColour = Color.white;
		yield return C.Shapes.Say("Huh.");
		yield return E.Break;
	}

	IEnumerator OnUseInvPropShrine( IProp prop, IInventory item )
	{
		if(item == I.Conception)
		{
			if(Globals.conceptionSense == senses.Sixth)
			{
				if(Globals.sensesSatisfied >= 4)
				{
					Audio.Play("sense_sixth");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					Audio.Play("conception_like");
					C.Shapes.RemoveInventory("Conception");
					yield return C.Display("Lost Conception");
					Audio.Play("god_bile_pickup");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("It dropped something...");
		
					C.Shapes.AddInventory("GodBile");
					yield return C.Display("Got God Bile");
				}
				else
				{
					Camera.Shake(1f,1f);
					Audio.Play("conception_dislike");
					yield return C.Shapes.Say("I must be missing something...");
				}
			}
			else
			{
				Camera.Shake(1f,1f);
				Audio.Play("conception_dislike");
				yield return C.Shapes.Say("Not quite...");
			}
		}
		yield return E.Break;
	}
}