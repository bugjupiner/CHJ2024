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
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Blanket)
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
			C.Shapes.RemoveInventory("Blanket");
			yield return C.Finger.PlayAnimation("BlanketOn");
			C.Finger.AnimIdle = "Dead";
			C.Finger.Clickable = false;
		
			Prop("Conception").Disable();
			yield return C.Display("Got Conception");
			C.Shapes.AddInventory("Conception");
		}
		
		yield return E.Break;
	}
}