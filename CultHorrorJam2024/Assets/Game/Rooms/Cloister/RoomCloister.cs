using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomCloister : RoomScript<RoomCloister>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Stairwell)
		{
			C.Player.Position = R.Current.GetHotspot("Stairwell").WalkToPoint;
		}
		else if(Globals.onCloisterGrass)
		{
			if(R.Previous == R.CloisterStart) C.Player.Position = R.Current.GetHotspot("CloisterStartGrass").WalkToPoint;
			if(R.Previous == R.CloisterEnd) C.Player.Position = R.Current.GetHotspot("CloisterEndGrass").WalkToPoint;
		}
		else
		{
			if(R.Previous == R.CloisterStart) C.Player.Position = R.Current.GetHotspot("CloisterStartStone").WalkToPoint;
			if(R.Previous == R.CloisterEnd) C.Player.Position = R.Current.GetHotspot("CloisterEndStone").WalkToPoint;
		}
		
		if(!Globals.conceptionSmelled) I.Conception.AnimGui = "ConceptionIconSpin";
	}

	IEnumerator OnInteractHotspotStairwell( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Stairwell;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterEndStone( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = false;
		C.Player.Room = R.CloisterEnd;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStartStone( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = false;
		C.Player.Room = R.CloisterStart;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterEndGrass( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = true;
		C.Player.Room = R.CloisterEnd;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStartGrass( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		Globals.onCloisterGrass = true;
		C.Player.Room = R.CloisterStart;
		yield return E.Break;
	}

	IEnumerator OnLookAtPropRubble( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("This place is a mess.");
		yield return E.Break;
	}

	IEnumerator OnInteractPropRubble( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("rubble_pickup_01");
		yield return C.Display("Got Rubble");
		C.Shapes.AddInventory("Rubble");
		Prop("Rubble").Disable();
		yield return E.Break;
	}

	IEnumerator OnInteractPropRoses( IProp prop )
	{
		yield return C.WalkToClicked();
		if(!Globals.fireglassActive)
		{
			yield return C.Shapes.Say("Garden's crispy.");
		}
		else
		{
			yield return C.Shapes.Say("There were roses here!");
		}
		yield return E.Break;
	}

	IEnumerator OnUseInvPropRoses( IProp prop, IInventory item )
	{
		if(Globals.fireglassActive)
		{
			yield return C.WalkToClicked();
			if(item == I.Conception)
			{
				if(Globals.conceptionSense == senses.Smell)
				{
					Audio.Play("sense_smell");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					Camera.Shake(1f,1f);
					Audio.Play("conception_like");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					Globals.sensesSatisfied += 1;
					Globals.conceptionSmelled = true;
					yield return C.Shapes.Say("It liked that!");
					Prop("Roses").Clickable = false;
				}
				else
				{
					Camera.Shake(1f,1f);
					Audio.Play("conception_dislike");
					yield return C.Shapes.Say("Not quite...");
				}
			}
		}
		
		
		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		Globals.UpdateConceptionSprite();
		yield return E.Break;
	}
}