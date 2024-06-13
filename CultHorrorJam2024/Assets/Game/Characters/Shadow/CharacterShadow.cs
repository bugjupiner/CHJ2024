using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterShadow : CharacterScript<CharacterShadow>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.Player.FaceLeft();
		yield return C.Shapes.Say("I know you...");
		yield return C.Shadow.Say("That's right.");
		yield return E.WaitSkip();
		yield return C.Shadow.Say("Like looking in a mirror.");
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Conception)
		{
			if(Globals.conceptionSense == senses.See)
			{
				yield return C.Shadow.Say("NO!");
				yield return C.Shadow.PlayAnimation("Die");
				C.Shadow.Disable();
		
				C.Shapes.AddInventory("SecondFace");
				yield return C.Display("Got Second Face");
			}
			else
			{
				yield return C.Shadow.Say("What is that little thing?");
			}
		}
		
		yield return E.Break;
	}
}