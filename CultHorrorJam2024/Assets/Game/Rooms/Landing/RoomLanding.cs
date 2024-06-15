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
}