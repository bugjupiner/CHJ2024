using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomBasement : RoomScript<RoomBasement>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Cells)
		{
			C.Player.Position = R.Current.GetHotspot("Cells").WalkToPoint;
		}
		else if(R.Previous == R.Stairwell)
		{
			C.Player.Position = R.Current.GetHotspot("Stairwell").WalkToPoint;
		}
		else if(R.Previous == R.Fork)
		{
			C.Player.Position = R.Current.GetHotspot("Fork").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotFork( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Fork;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotStairwell( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Stairwell;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCells( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Cells;
		yield return E.Break;
	}
}