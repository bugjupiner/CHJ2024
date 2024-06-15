using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomCloisterEnd : RoomScript<RoomCloisterEnd>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Cloister)
		{
			if(Globals.onCloisterGrass) C.Player.Position = R.Current.GetHotspot("CloisterGrass").WalkToPoint;
			else C.Player.Position = R.Current.GetHotspot("CloisterStone").WalkToPoint;
		}
		else if(R.Previous == R.Dorm)
		{
			C.Player.Position = R.Current.GetProp("PortalDorm").WalkToPoint;
		}
	}

	IEnumerator OnInteractHotspotCloisterStone( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = false;
		C.Player.Room = R.Cloister;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterGrass( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = true;
		C.Player.Room = R.Cloister;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotRobe( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("dormant_soul_pickup");
		C.Shapes.AddInventory("FacelessSoul");
		yield return C.Display("Got Faceless Soul");
		Hotspot("Robe").Disable();
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