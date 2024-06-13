using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterPastAngel : CharacterScript<CharacterPastAngel>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		
		if(Globals.secondFace)
		{
			if(!Globals.mirrorScrollFree)
			{
				yield return C.PastAngel.Say("Vesta! My goddess!");
				yield return C.PastAngel.Say("You've come to save me, haven't you?");
				yield return E.WaitSkip();
				yield return C.PastAngel.Say("Oh, but it wouldn't stop her. She's planned for many outcomes.");
				yield return C.PastAngel.Say("She's cunning...");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.PastAngel.Say("But not as cunning as us, my goddess.");
				yield return C.PastAngel.Say("I've caught onto her contigency, and locked her spell away.");
				yield return E.WaitSkip();
				yield return C.PastAngel.Say("I shall break the lock so that you can take it and protect yourself.");
				yield return E.WaitSkip();
				yield return C.PastAngel.Say("My goddess, I will burn for you.");
				Globals.mirrorScrollFree = true;
			}
			else
			{
				yield return C.PastAngel.Say("Vesta, you must go!");
				yield return C.PastAngel.Say("Find and take the High Witch's scroll.");
				yield return C.PastAngel.Say("Make sure that she nor anyone else can use it.");
			}
		}
		else
		{
			yield return C.PastAngel.Say("What... what are you?");
			yield return E.WaitSkip();
			yield return E.WaitSkip(0.25f);
			yield return C.PastAngel.Say("When are you?");
			yield return E.WaitSkip();
			yield return C.PastAngel.Say("It doesn't matter, you have to help me!");
			yield return C.PastAngel.Say("The High Witch, she wants more than my blood.");
			yield return E.WaitSkip();
			yield return C.PastAngel.Say("She's going to burn me alive!");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.PastAngel.Say("Please, by the goddess, help me!");
		}
		
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Knife && !I.AngelsBlood.EverCollected)
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
			yield return C.Display("Got Angel's Blood");
			yield return C.PastAngel.Say("Ouch!");
			C.Shapes.AddInventory("AngelsBlood");
		}
		yield return E.Break;
	}
}