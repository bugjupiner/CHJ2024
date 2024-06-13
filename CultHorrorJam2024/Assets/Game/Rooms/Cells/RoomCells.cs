using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomCells : RoomScript<RoomCells>
{


	IEnumerator OnInteractHotspotBarrels( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("Yep. Barrels.");
		yield return E.Break;
	}

	IEnumerator OnEnterRegionBars( IRegion region, ICharacter character )
	{
		yield return E.Break;
	}

	IEnumerator OnExitRegionBars( IRegion region, ICharacter character )
	{
		yield return E.Break;
	}

	IEnumerator OnInteractCharacterShapes( ICharacter character )
	{
		//Region("Bars").Walkable = Globals.jumbled;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotBasement( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(C.Player.TargetPosition == Hotspot("Basement").WalkToPoint) C.Player.Room = R.Basement;
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		if(R.Previous == R.Basement)
		{
			C.Player.Position = R.Current.GetHotspot("Basement").WalkToPoint;
		}
	}

	IEnumerator UpdateBlocking()
	{
		
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotStoreroom( IHotspot hotspot )
	{
		if(Globals.jumbled)
		{
			yield return C.WalkToClicked();
			C.Player.Room = R.Storeroom;
		}
		else
		{
			yield return C.Shapes.Say("Looks smelly...");
		}
		yield return E.Break;
	}

	void OnEnterRegionBGBars( IRegion region, ICharacter character )
	{
	}

	void OnExitRegionBGBars( IRegion region, ICharacter character )
	{
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		if (!Audio.IsPlaying("Music_Basement_Loop"))
		{
					Audio.PlayMusic("Music_Basement_Loop");
		}
		
		if(!Globals.angelTutorial)
		{
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Angel.Say("Heh heh... Awake?");
			yield return E.WaitSkip();
			yield return C.Shapes.FaceLeft();
			yield return C.Shapes.Say("Hello?");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Angel.Say("Don't tell me you're stuck.");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Shapes.Say("I'm stuck.");
			yield return E.WaitSkip();
			yield return C.Angel.Say("But...");
			yield return E.WaitSkip();
			C.Angel.AnimTalk = "AltTalk";
			yield return C.Angel.Say("But I want to see you.");
			yield return E.WaitSkip();
			C.Angel.AnimTalk = "Talk";
			yield return C.Angel.Say("Find a way out, why don't you?");
		}
		
		yield return E.Break;
	}

	IEnumerator OnEnterRegionOutsideCells( IRegion region, ICharacter character )
	{
		if(!Globals.angelTutorial)
		{
			Globals.angelTutorial = true;
			C.Angel.AnimTalk = "Talk";
			yield return C.Angel.Say("HA HA HA");
			yield return E.WaitSkip();
			yield return C.Angel.Say("The jumbling! It's funny!");
			yield return E.WaitSkip();
			C.Angel.AnimTalk = "AltTalk";
			yield return C.Angel.Say("To see your pieces spin...");
			yield return C.Angel.Say("heh heh heh.");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			C.Angel.AnimTalk = "Talk";
			yield return C.Angel.Say("Good luck out there. Something bad spread around.");
			yield return E.WaitSkip();
			C.Angel.AnimTalk = "AltTalk";
			yield return C.Angel.Say("If you find any, hehe, literature...");
			C.Angel.AnimTalk = "Talk";
			yield return C.Angel.Say("You might find me USEFUL");
		}
		yield return E.Break;
	}
}