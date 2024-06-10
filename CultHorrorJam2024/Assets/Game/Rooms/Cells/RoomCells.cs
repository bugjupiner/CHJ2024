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
		yield return C.Display("Yep. Barrels.");
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
		C.Player.Room = R.Basement;
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
		if (!Audio.IsPlaying("Cells"))
		{
					Audio.PlayMusic("Cells");
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
			yield return E.ConsumeEvent;
		}
		yield return E.Break;
	}
}