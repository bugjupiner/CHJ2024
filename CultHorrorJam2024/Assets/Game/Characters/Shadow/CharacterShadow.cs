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
		
		if(C.Shadow.FirstUse) // First encounter
		{
			Audio.Play("shadow_talk");
			yield return C.Shapes.Say("Finally, a friend!");
			yield return E.WaitSkip();
			yield return C.Shadow.Say("I've been waiting for you.");
			yield return C.Shapes.Say("Oh! Really?");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			Audio.Play("shadow_talk");
			yield return C.Shadow.Say("Really.");
			yield return E.WaitSkip();
			yield return C.Shadow.Say("My most trusted friend.");
			yield return C.Shadow.Say("Tell me, what is our biggest threat?");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("Well, uh, it's the...");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("Um...");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			C.Shapes.SayBG("It's the—");
			Audio.Play("shadow_talk");
			yield return C.Shadow.Say("The Wizard.");
			yield return C.Shapes.Say("The Wizard! Yes.");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Shadow.Say("Help me, friend.");
			Audio.Play("shadow_talk");
			yield return C.Shadow.Say("Siphon plans from the Wizard's mind.");
			yield return C.Shadow.Say("Use ears that aren't your own.");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("What?");
			Audio.Play("shadow_death_01");
			yield return C.Shadow.Say("GO!");
		
			yield return C.Shapes.FaceRight();
			C.Shapes.SayBG("Alright!");
		}
		
		if(!C.Shapes.HasInventory("Conception"))
		{
			Audio.Play("shadow_talk");
			yield return C.Shadow.Say("Help me, friend.");
			yield return C.Shadow.Say("Siphon plans from the Wizard's mind.");
			Audio.Play("shadow_talk");
			yield return C.Shadow.Say("Use ears that aren't your own.");
		}
		else
		{
			if(!Globals.wizardListenedTo)
			{
				Audio.Play("shadow_talk");
				yield return C.Shadow.Say("Ah, my friend, you've found the right tool.");
				yield return E.WaitSkip();
				yield return C.Shapes.Say("This cube thing?");
				yield return C.Shadow.Say("It belongs to you, as it always has.");
				yield return E.WaitSkip();
				Audio.Play("shadow_talk");
				yield return C.Shadow.Say("Use it wisely on the Wizard, learn his secrets.");
			}
			else if(!Globals.wizardSpellBroken)
			{
				Audio.Play("shadow_talk");
				yield return C.Shadow.Say("The Wizard would rather sacrifice his life,");
				yield return C.Shadow.Say("Than let another hearth light.");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				Audio.Play("shadow_talk");
				yield return C.Shadow.Say("Let's grant his wish, friend.");
				yield return C.Shapes.Say("Right! That's true.");
				yield return E.WaitSkip();
				Audio.Play("shadow_talk");
				yield return C.Shadow.Say("Use something heavy and bash his brains!");
				yield return C.Shadow.Say("Spill blood, let it cover his landing!");
				Audio.Play("shadow_death_01");
				yield return C.Shadow.Say("My friend should drink the blood, should gulp it down!");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Shapes.Say("Of course, friend!");
			}
			else
			{
				Audio.Play("shadow_talk");
				yield return C.Shadow.Say("Ahh, I can feel it now...");
				yield return E.WaitSkip();
				yield return C.Shadow.Say("The hearth's warmth.");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				Audio.Play("shadow_talk");
				yield return C.Shadow.Say("It will light up the sky, soon.");
			}
		
		}
		
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Conception)
		{
			if(Globals.conceptionSense == senses.See)
			{
				C.Shadow.SayBG("NO!");
				yield return C.Shadow.PlayAnimation("Die");
				C.Shadow.Disable();
		
				C.Shapes.AddInventory("SecondFace");
				yield return C.Display("Got Second Face");
		
				C.Ghost.Disable();
			}
			else
			{
				Audio.Play("shadow_talk");
				yield return C.Shadow.Say("Keep that thing AWAY from me!");
				yield return C.Shapes.Say(" Sorry, sorry!");
			}
		}
		
		yield return E.Break;
	}
}