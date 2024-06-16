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
		
		if(!Globals.conceptionHeard) I.Conception.AnimGui = "ConceptionIconSpin";
		
		Audio.Play("shell_loop");
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
				Audio.Play("sense_hear");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				Camera.Shake(1f,1f);
				Audio.Play("conception_like");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Shapes.Say("It liked that!");
				Globals.sensesSatisfied += 1;
				Globals.conceptionHeard = true;
				Hotspot("Shell").Disable();
			}
			else
			{
				Camera.Shake(1f,1f);
				Audio.Play("conception_dislike");
				yield return C.Shapes.Say(" Not Quite...");
			}
		}
		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		Globals.UpdateConceptionSprite();
		Audio.Stop("shell_loop");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotShell( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Has that always been here?");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotShell( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("Sounds nice...");
		yield return E.Break;
	}

	void Update()
	{
		Audio.UpdateCustomFalloff("shell_loop", C.Shapes.Position, Hotspot("Shell").WalkToPoint, 10f, 100f, 0f, 1f);
	}

	IEnumerator OnLookAtHotspotFront( IHotspot hotspot )
	{
		yield return C.Shapes.Say("This must be the front of the castle.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotDoor( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Why is that door upside down?");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotDoor( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("That's wrong.");
		yield return E.Break;
	}
}