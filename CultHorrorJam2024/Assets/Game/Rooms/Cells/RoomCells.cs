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
		if (!Audio.IsPlaying("Music_Basement_Loop"))
		{
					Audio.PlayMusic("Music_Basement_Loop");
		}
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
}