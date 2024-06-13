using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterAngel : CharacterScript<CharacterAngel>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		
		
		if(!Globals.angelTutorial)
		{
			yield return C.Angel.Say("I'm sure there's something you can do to get outta there.");
		}
		else if(Globals.secondFace)
		{
			yield return C.Angel.Say("It's you... my goddess...");
			yield return C.Angel.Say("My... hehehe... my...");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Angel.Say("I can't say it any more.");
			C.Angel.AnimTalk = "AltTalk";
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Angel.Say("I— It's not me, it's you.");
		}
		else if(!Globals.angelVolumeOne && !Globals.angelVolumeTwo) // no books
		{
			C.Angel.AnimTalk = "AltTalk";
			yield return C.Angel.Say("If you find any literature, bring it.");
			yield return E.WaitSkip();
			yield return C.Angel.Say("You might find me");
			C.Angel.AnimTalk = "Talk";
			yield return C.Angel.Say("USEFUL");
		}
		else if(Globals.angelVolumeOne && !Globals.angelVolumeTwo) // first book
		{
			if(!Globals.hearthSummoned)
			{
				yield return C.Angel.Say("Huh? You want to know about the book?");
				yield return C.Angel.Say("You could've asked before. I already know.");
				yield return E.WaitSkip();
				yield return C.Angel.Say("To summon Vesta's hearth, first find a fire...");
				yield return E.WaitSkip();
				yield return C.Angel.Say("Then sacrifice a doll and virgin's blood into it.");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				C.Angel.AnimTalk = "AltTalk";
				yield return C.Angel.Say("And if — hehehe");
				C.Angel.AnimTalk = "Talk";
				yield return C.Angel.Say("You'd like to know a secret, or two,");
				C.Angel.AnimTalk = "AltTalk";
				yield return C.Angel.Say("Throw in some glass after.");
			}
			else
			{
				C.Angel.AnimTalk = "AltTalk";
				yield return C.Angel.Say("I feel it...");
				yield return E.WaitSkip();
				yield return C.Angel.Say("Her warmth... Vesta...");
				yield return E.WaitSkip();
				yield return C.Angel.Say("Goddess of Hearth and Home....");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				C.Angel.AnimTalk = "Talk";
				yield return C.Angel.Say("HAAHAHA");
				yield return E.WaitSkip();
				yield return C.Angel.Say("The thought of her makes me laugh");
				yield return C.Angel.Say("And makes me hungry");
				yield return E.WaitSkip();
				C.Angel.AnimTalk = "AltTalk";
				yield return C.Angel.Say("Fetch me another SNACK!");
			}
		}
		else
		{
			C.Angel.AnimTalk = "AltTalk";
			yield return C.Angel.Say("Wanna summon a goddess?");
			yield return C.Angel.Say("All's you need is something called Lavinia's Hair...");
			C.Angel.AnimTalk = "Talk";
			yield return C.Angel.Say("And, hehe, Angel blood.");
		
			if(Globals.angelScroll)
			{
				yield return E.WaitSkip();
				yield return C.Angel.Say("If the spell brings Vesta home,");
				yield return C.Angel.Say("Inverting it brings home to Vesta.");
				yield return E.WaitSkip();
				C.Angel.AnimTalk = "AltTalk";
				yield return C.Angel.Say("In other words, absorb a god and all their power.");
				yield return E.WaitSkip();
				C.Angel.AnimTalk = "Talk";
				yield return C.Angel.Say("If that interests you, don't add Lavinia's Hair to the hearth,");
				yield return C.Angel.Say("Add something called God Bile instead");
				yield return E.WaitSkip();
				C.Angel.AnimTalk = "AltTalk";
				yield return C.Angel.Say("Hehe, that should work...");
			}
		}
		
		
		
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.SpellbookOne) // Spellbook Volume One
		{
			C.Angel.AnimTalk = "Talk";
			yield return C.Angel.Say("One of the High Witch's spellbooks!");
			yield return C.Angel.Say("HAHAHA");
			yield return E.WaitSkip();
			C.Angel.AnimTalk = "AltTalk";
			yield return C.Angel.Say("Oh this is perfect. Thank you for bringing it.");
			yield return E.WaitSkip();
			C.Angel.AnimTalk = "Talk";
			yield return C.Angel.Say("Let me see here...");
			C.Angel.AnimTalk = "AltTalk";
			yield return C.Angel.Say("Hm... tasty.. yes, what crunch!");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			C.Angel.AnimTalk = "Talk";
			yield return C.Angel.Say("I REALLY needed a snack.");
		
			Globals.angelVolumeOne = true;
			I.SpellbookOne.Active = false;
			C.Shapes.RemoveInventory("SpellbookOne");
			yield return C.Display("Lost Spellbook Volume One");
		}
		if(item == I.SpellbookTwo) // Spellbook Volume One
		{
			if(!Globals.hearthSummoned)
			{
				yield return C.Angel.Say("Oh, this is too much for right now.");
				if(Globals.angelVolumeOne)
				{
					yield return C.Angel.Say("Why don't you and me talk about that other book?");
				}
			}
			else
			{
				yield return C.Angel.Say("Yes... yess...");
				yield return C.Angel.Say("The text for summoning the goddess herself...");
				yield return E.WaitSkip();
				yield return C.Angel.Say("I'm gunna eat this.");
		
				Globals.angelVolumeTwo = true;
				I.SpellbookTwo.Active = false;
				C.Shapes.RemoveInventory("SpellbookTwo");
		
				yield return C.Display("Lost Spellbook Volume Two");
			}
		}
		if(item == I.InversionScroll) // Scroll
		{
			if(!Globals.angelVolumeTwo)
			{
				C.Angel.AnimTalk = "Talk";
				yield return C.Angel.Say("I don't have the appetite for scrolls.");
				C.Angel.AnimTalk = "AltTalk";
				yield return C.Angel.Say("Aren't there any more books?");
			}
			else
			{
				yield return C.Angel.Say("An inversion of scroll!");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Angel.Say(" Oh wait. Hehehe.");
				yield return E.WaitSkip();
				yield return C.Angel.Say("I think if I ate this, I think I'd get hungrier.");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Angel.Say("When in Rome!");
				yield return E.WaitSkip();
		
				Globals.angelScroll = true;
				I.InversionScroll.Active = false;
				C.Shapes.RemoveInventory("InversionScroll");
		
				yield return C.Display("Lost Scroll of Inversion");
			}
		}
		
		yield return E.Break;
	}
}