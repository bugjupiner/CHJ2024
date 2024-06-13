using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomStoreroom : RoomScript<RoomStoreroom>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Fork)
		{
			C.Player.Position = R.Current.GetHotspot("Fork").WalkToPoint;
		}
		else if(R.Previous == R.Cells)
		{
			C.Player.Position = R.Current.GetPoint("Cells");
		}
		
		Audio.Play("worm_groan_03");
	}

	IEnumerator OnInteractHotspotFork( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Fork;
		yield return E.Break;
	}

	IEnumerator OnInteractPropDollHead( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Display("Got Doll Head");
		C.Shapes.AddInventory("DollHead");
		Prop("DollHead").Disable();
		yield return E.Break;
	}
}