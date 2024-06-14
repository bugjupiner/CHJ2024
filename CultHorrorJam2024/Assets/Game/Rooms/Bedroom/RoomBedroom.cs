using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomBedroom : RoomScript<RoomBedroom>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.Entryway)
		{
			C.Player.Position = R.Current.GetHotspot("Entryway").WalkToPoint;
		}
		
		if(!Globals.conceptionSaw) I.Conception.AnimGui = "ConceptionIconSpin";
		
	}

	IEnumerator OnInteractHotspotEntryway( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Entryway;
		yield return E.Break;
	}

	IEnumerator OnLookAtPropDiary( IProp prop )
	{
		yield return C.Shapes.Say("It's a diary...");
		yield return C.Shapes.Say(" 'Casina' is written on the cover.");
		yield return E.Break;
	}

	IEnumerator OnInteractPropDiary( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.FaceRight();
		int page = Prop("Diary").UseCount % 2;
		
		if(page == 0)
		{
			yield return C.Shapes.Say("This is the High Witch's Diary!");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("There's an entry from two days ago:");
			yield return E.WaitSkip();
			C.Shapes.AnimTalk = "Idle";
			C.Shapes.TextColour = new Color(0.8f, 0.8f, 1f, 1f);
			yield return C.Shapes.Say("With the hearth in order and sacrifices secure...");
			yield return C.Shapes.Say("... Everything is ready to go wrong.");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("Vesta won't accept her new home so easily.");
			yield return C.Shapes.Say("It's likely I'll have to pack up and leave first.");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("If that's the case, perhaps I should prepare...");
			yield return E.WaitSkip();
			C.Shapes.TextColour = Color.white;
			C.Shapes.AnimTalk = "Talk";
			yield return C.Shapes.Say("Looks like there's one more entry.");
		}
		else if (page == 1)
		{
			yield return C.Shapes.Say("There's a diary entry from yesterday.");
			yield return E.WaitSkip();
			C.Shapes.AnimTalk = "Idle";
			C.Shapes.TextColour = new Color(0.8f, 0.8f, 1f, 1f);
			yield return C.Shapes.Say("The Omen arrived as scheduled.");
			yield return C.Shapes.Say("Through the fireglass I could take what was mine.");
			yield return C.Shapes.Say("And as everything falls into place... I can see now...");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("It's almost certain that I will fail.");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("Yet, should my will be strong enough...");
			yield return C.Shapes.Say("Nothing could stop me.");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("Not some pesky magician.");
			yield return C.Shapes.Say("Not Vesta's power.");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Shapes.Say("No, not even my death.");
			yield return E.WaitSkip();
			C.Shapes.TextColour = Color.white;
			C.Shapes.AnimTalk = "Talk";
			yield return C.Shapes.Say("That's all she wrote.");
		}
		
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotMirrorConception( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.FaceLeft();
		
		yield return C.Shapes.Say("Don't see much...");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotMirrorConception( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.FaceLeft();
		
		yield return C.Shapes.Say("Don't see much...");
		yield return E.Break;
	}

	IEnumerator OnUseInvHotspotMirrorConception( IHotspot hotspot, IInventory item )
	{
		yield return C.WalkToClicked();
		
		if(item == I.Conception)
		{
			if(Globals.conceptionSense == senses.See)
			{
				Camera.Shake(1f,1f);
				Audio.Play("conception_like");
		
				Globals.sensesSatisfied += 1;
				Globals.conceptionSaw = true;
				yield return C.Shapes.Say("It liked that!");
				Hotspot("MirrorConception").Disable();
			}
			else
			{
				Camera.Shake(1f,1f);
				Audio.Play("conception_dislike");
				yield return C.Shapes.Say("Not quite...");
			}
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotMirrorSwitch( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.FaceLeft();
		yield return C.Shapes.Say("Who is that?");
		yield return C.Shapes.Say("Why is she staring?");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotMirrorSwitch( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.FaceLeft();
		
		if(Globals.jumbled)
		{
			E.FadeColor = Color.white;
			yield return E.FadeOut(0.1f);
			Globals.SwitchMirrorState();
			E.FadeColor = Color.white;
			yield return E.FadeIn(0.3f);
		}
		else
		{
			yield return C.Shapes.Say("Who is that?");
			yield return C.Shapes.Say("Why is she staring?");
		}
		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		Globals.UpdateConceptionSprite();
		yield return E.Break;
	}
}