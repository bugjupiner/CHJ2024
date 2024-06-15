using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomBasement : RoomScript<RoomBasement>
{


	void OnEnterRoom()
	{
		if(Globals.basementDoorOpened && !Prop("Door").Visible) Prop("Door").Visible = true;
		
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
		else if(R.Previous == R.Dorm)
		{
			C.Player.Position = R.Current.GetProp("PortalDorm").WalkToPoint;
		}
		
		
	}

	IEnumerator OnInteractHotspotFork( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(C.Player.TargetPosition == Hotspot("Fork").WalkToPoint) C.Player.Room = R.Fork;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotStairwell( IHotspot hotspot )
	{
		
		yield return C.WalkToClicked();
		if(C.Player.TargetPosition != Hotspot("Stairwell").WalkToPoint)
		{
			yield return E.ConsumeEvent;
		}
		else
		{
			if(Globals.basementDoorOpened) C.Player.Room = R.Stairwell;
			else
			{
				yield return C.Shapes.Say("Locked.");
			}
		}
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCells( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(C.Player.TargetPosition == Hotspot("Cells").WalkToPoint) C.Player.Room = R.Cells;
		yield return E.Break;
	}

	IEnumerator OnInteractPropPortalDorm( IProp prop )
	{
		yield return C.WalkToClicked();
		Audio.Play("portal");
		C.Player.Room = R.Dorm;
		yield return E.Break;
	}

	IEnumerator OnLookAtPropPortalDorm( IProp prop )
	{
		yield return C.Shapes.Say("It's a portal!");
		yield return E.Break;
	}
}