using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterFinger : CharacterScript<CharacterFinger>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Finger.Say("...");
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return C.Shapes.Say("Hello?");
		yield return C.Finger.Say("...");
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return C.Shapes.Say("Okay...");
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Blanket)
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
			I.Blanket.Active = false;
			C.Shapes.RemoveInventory("Blanket");
			yield return C.Display("Lost Blanket");
		
			yield return C.Finger.PlayAnimation("BlanketOn");
			C.Finger.AnimIdle = "Dead";
			C.Finger.Clickable = false;
		
			Prop("Conception").Disable();
		
			yield return C.Display("Got Conception");
			C.Shapes.AddInventory("Conception");
		}
		if(item == I.DormantSoul)
		{
			yield return C.WalkToClicked();
			yield return C.Shapes.FaceRight();
			yield return C.Shapes.Say("Is this yours?");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Finger.Say("...");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("That's what I thought.");
		}
		
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{
		yield return C.Shapes.Say("I don't think fingers belong there.");
		yield return E.Break;
	}
}