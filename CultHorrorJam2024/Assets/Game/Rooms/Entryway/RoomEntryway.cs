using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomEntryway : RoomScript<RoomEntryway>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Front)
		{
			C.Player.Position = R.Current.GetHotspot("Front").WalkToPoint;
		}
		else if(R.Previous == R.CloisterStart)
		{
			C.Player.Position = R.Current.GetHotspot("CloisterStart").WalkToPoint;
		}
		else if(R.Previous == R.Bedroom)
		{
			C.Player.Position = R.Current.GetHotspot("Bedroom").WalkToPoint;
		}
		
		if(Globals.hearthSummoned && !I.Glass.EverCollected)
		{
			Prop("FireParticles").Instance.transform.GetChild(0).gameObject.SetActive(true);
		}
	}

	IEnumerator OnInteractHotspotBedroom( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(Globals.secondFace) C.Player.Room = R.Bedroom;
		else
		{
			yield return C.Shapes.Say("What is this?");
		}
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStart( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(Globals.jumbled) C.Player.Room = R.CloisterStart;
		else
		{
			yield return C.Shapes.Say("It's hot.");
		}
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotFront( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Front;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotBigDoor( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("Locked.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotFront( IHotspot hotspot )
	{
		yield return C.Shapes.Say("This goes outside.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotCloisterStart( IHotspot hotspot )
	{
		yield return C.Shapes.FaceLeft();
		yield return C.Shapes.Say("I think that leads outside...");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotBedroom( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Almost looks like a face.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotBigDoor( IHotspot hotspot )
	{
		yield return C.Shapes.FaceLeft();
		yield return C.Shapes.Say("Whoever built this place loves big doors.");
		yield return E.Break;
	}
}