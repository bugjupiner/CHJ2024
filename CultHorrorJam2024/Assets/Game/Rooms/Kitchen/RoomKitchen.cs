using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomKitchen : RoomScript<RoomKitchen>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Yard)
		{
			C.Player.Position = R.Current.GetHotspot("Yard").WalkToPoint;
		}
		else if(R.Previous == R.Dorm)
		{
			C.Player.Position = R.Current.GetHotspot("Dorm").WalkToPoint;
		}
		else if(R.Previous == R.HiddenRoom)
		{
			C.Player.Position = R.Current.GetHotspot("HiddenRoom").WalkToPoint;
		}
		
		if(!Globals.conceptionTasted) I.Conception.AnimGui = "ConceptionIconSpin";
		
	}

	IEnumerator OnInteractHotspotHiddenRoom( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(Globals.jumbled && Globals.fireglassActive) C.Player.Room = R.HiddenRoom;
		else
		{
			yield return C.Shapes.Say("It's a fireplace.");
		}
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotDorm( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(Globals.dormDoorOpened) C.Player.Room = R.Dorm;
		else
		{
			yield return C.Shapes.Say("Huh?");
			yield return C.Shapes.Say("Something is pushing me away...");
		}
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotYard( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Yard;
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotFridge( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("There's food in here.");
		yield return C.Shapes.Say("Looks tasty!");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotFridge( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("There's food in here.");
		yield return C.Shapes.Say("Looks tasty!");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropCookedRat( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("That's a cooked rat.");
		yield return E.Break;
	}

	IEnumerator OnUseInvHotspotDorm( IHotspot hotspot, IInventory item )
	{
		if(item == I.DormantSoul)
		{
			I.DormantSoul.Active = false;
			C.Shapes.RemoveInventory("DormantSoul");
			Globals.dormDoorOpened = true;
			Audio.Play("dormant_soul_use");
			yield return C.Display("Lost Dormant Soul");
			yield return C.Shapes.Say("Seems like I can get in there now!");
		}
		yield return E.Break;
	}

	IEnumerator OnUseInvHotspotFridge( IHotspot hotspot, IInventory item )
	{
		if(item == I.Conception)
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
		
			if(Globals.conceptionSense == senses.Taste)
			{
				Audio.Play("sense_taste");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				Camera.Shake(1f,1f);
				Audio.Play("conception_like");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Shapes.Say("It liked that!");
				Globals.sensesSatisfied += 1;
				Globals.conceptionTasted = true;
				Hotspot("Fridge").Disable();
			}
			else
			{
				Camera.Shake(1f,1f);
				Audio.Play("conception_dislike");
				yield return C.Shapes.Say(" Not Quite...");
			}
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropCookedRat( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("That's a cooked rat.");
		yield return E.Break;
	}

	IEnumerator UpdateBlocking()
	{
		
		yield return E.Break;
	}

	IEnumerator AfterAnyClick()
	{
		
		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		Globals.UpdateConceptionSprite();
		yield return E.Break;
	}
}