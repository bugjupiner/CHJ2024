using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomCloisterStart : RoomScript<RoomCloisterStart>
{
	public AudioHandle omenFire = null;
	
	void OnEnterRoom()
	{
		if(R.Previous == R.Entryway)
		{
			C.Player.Position = R.Current.GetHotspot("Entryway").WalkToPoint;
		}
		else if(R.Previous == R.Cloister)
		{
			if(Globals.onCloisterGrass) C.Player.Position = R.Current.GetHotspot("CloisterGrass").WalkToPoint;
			else C.Player.Position = R.Current.GetHotspot("CloisterStone").WalkToPoint;
		}
		else if(R.Previous == R.Pathway)
		{
			C.Player.Position = R.Current.GetHotspot("Pathway").WalkToPoint;
		}
		
		omenFire = Audio.Play("small_fire_loop");
		
		if(Globals.hearthSummoned && !I.Glass.EverCollected)
		{
			Prop("FireParticles").Visible = true;
		}
		else
		{
			Prop("FireParticles").Visible = false;
		}
	}

	IEnumerator OnInteractHotspotCloisterGrass( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = true;
		C.Player.Room = R.Cloister;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotPathway( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Pathway;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStone( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = false;
		C.Player.Room = R.Cloister;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotEntryway( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(Globals.jumbled) C.Player.Room = R.Entryway;
		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		Audio.Stop(omenFire);
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotPathway( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Yup.");
		yield return C.Shapes.Say("The world must've exploded.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotCloisterStone( IHotspot hotspot )
	{
		yield return C.Shapes.Say("More cloister.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotCloisterGrass( IHotspot hotspot )
	{
		yield return C.Shapes.Say("More cloister.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotEntryway( IHotspot hotspot )
	{
		yield return C.Shapes.Say("This leads inside.");
		yield return E.Break;
	}
}