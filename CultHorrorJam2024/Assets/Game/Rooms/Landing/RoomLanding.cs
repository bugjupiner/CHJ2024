using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomLanding : RoomScript<RoomLanding>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Front)
		{
			C.Player.Position = R.Current.GetHotspot("Front").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotFront( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Front;
		yield return E.Break;
	}

	IEnumerator OnUseInvHotspotShell( IHotspot hotspot, IInventory item )
	{
		if(item == I.Conception)
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
		
			if(Globals.conceptionSense == senses.Hear)
			{
				yield return C.Shapes.Say("It liked that!");
				Globals.sensesSatisfied += 1;
				Hotspot("Shell").Disable();
			}
			else
			{
				yield return C.Shapes.Say(" Not Quite...");
			}
		}
		yield return E.Break;
	}
}