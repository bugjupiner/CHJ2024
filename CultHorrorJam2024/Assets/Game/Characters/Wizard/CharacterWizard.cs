using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterWizard : CharacterScript<CharacterWizard>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		if(!Globals.secondFace) // Default
		{
			Audio.Play("wizard_talk");
			yield return C.Wizard.Say("This isn't right.");
			yield return C.Wizard.Say("You're to be imprisoned!");
			yield return E.WaitSkip();
			Audio.Play("wizard_talk");
			yield return C.Wizard.Say("Oh well.");
		}
		else
		{
			Audio.Play("wizard_talk");
			yield return C.Wizard.Say("Ah, my trusty familiar!");
			yield return C.Wizard.Say("Catch any flies lately? Bwa ha!");
			yield return E.WaitSkip();
			Audio.Play("wizard_talk");
			yield return C.Wizard.Say("Oh is that so? Several? Why, they must fear you, surely.");
			yield return E.WaitSkip();
			yield return C.Wizard.Say("Now that you're here, suppose those spell bubbles are of no use.");
			yield return C.Wizard.Say("Yes, yes. Your frog magic shall keep the evil at bay.");
		
			Globals.wizardSpellBroken = true;
		
			yield return E.WaitSkip();
			E.FadeColor = Color.white;
			yield return E.FadeOut(0.1f);
			E.FadeColor = Color.white;
			yield return E.FadeIn(0.2f);
		
			yield return C.Display("The Wizard's Spell Was Broken");
		}
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Knife || item == I.Rubble)
		{
			I.Knife.Active = false;
			I.Rubble.Active = false;
		
			Audio.Play("wizard_death");
			C.Wizard.AnimIdle = "Dead";
			C.Wizard.AnimTalk = "Dead";
			yield return C.Wizard.Say("GAH!");
		
			C.Wizard.Clickable = false;
			Globals.wizardSpellBroken = true;
		
			E.FadeColor = Color.white;
			yield return E.FadeOut(0.1f);
			E.FadeColor = Color.white;
			yield return E.FadeIn(0.2f);
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Display("The Wizard's Spell Was Broken");
		}
		if(item == I.Conception)
		{
			if(Globals.conceptionSense == senses.Hear)
			{
					C.Wizard.AnimTalk = "Idle";
					Audio.Play("wizard_talk");
					yield return C.Wizard.Say("... and his little ribbits, by god.");
					yield return C.Wizard.Say("Why, if he were here, my presence would be obsolete!");
					yield return C.Wizard.Say("I could release my protective spells over those books!");
					yield return E.WaitSkip();
					yield return C.Wizard.Say("Alas, the songs from my years in wizard school persist.");
					yield return E.WaitSkip();
					yield return C.Wizard.Say("Smell Trouble? Spell Bubble! Smell Trouble? Spell Bubble!");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Wizard.Say("What an annoying song.");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					Audio.Play("wizard_talk");
					yield return C.Wizard.Say("I better not die here.");
		
					 C.Wizard.AnimTalk = "Talk";
					Globals.wizardListenedTo = true;
			}
			else
			{
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("What a peculiar object...");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("Where did you get this?");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("What does it do? Have you upset it in some way?");
				yield return C.Wizard.Say("I wouldn't want to upset a freaky thing like this, no!");
			}
		}
		
		if(item == I.SpellbookOne || item == I.SpellbookTwo || item == I.InversionScroll || item == I.MirrorScroll)
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
		
			if(!Globals.secondFace)
			{
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("How did you get this?");
				yield return C.Wizard.Say("You're not supposed to have this!");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("AND you're to be imprisoned!");
				yield return C.Wizard.Say("Why, this place is a mad house!");
				yield return C.Wizard.Say("Hell has broken loose!");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("Well, go on then.");
			}
			else if(item == I.SpellbookOne) // Spellbook One Lore
			{
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("Oh, how good it is to see you again?");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("What's this? You'd like to discuss this text?");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("Why? Such magics are beneath your power...");
				yield return C.Wizard.Say("Nevermind, I shan't question your pursuits.");
				yield return C.Wizard.Say("I could not conceive of what glorious outcome awaits you.");
				yield return E.WaitSkip();
		
				C.Wizard.AnimIdle = "AltIdle";
				C.Wizard.AnimTalk = "AltTalk";
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("Let's take a look, shall we?");
				yield return C.Wizard.Say("Hm...");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Wizard.Say("The book details fairly ordinary rituals dedicated to Vesta.");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("The ritual, once complete, would leave a hearth,");
				yield return C.Wizard.Say("Which, if successful, could lead the caster 'home' in some way.");
				yield return E.WaitSkip();
				yield return C.Shapes.Say("Home?");
				yield return E.WaitSkip();
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("Well, yes, in a manner of speaking.");
				yield return C.Wizard.Say("Family could be more likely to pay visit.");
				yield return C.Wizard.Say("Or if you were lost, the smoke could lead you to safety.");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("To summon a hearth of Vesta,");
				yield return C.Wizard.Say("You must first start or find a fire.");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("Then, you must burn a doll ...");
				yield return C.Wizard.Say("And add a drop of Virgin's blood.");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("Old chap, I'm afraid I'll be of no help to you there.");
				yield return E.WaitSkip();
				yield return E.WaitSkip(1.0f);
				C.Wizard.SayBG("....");
				yield return C.Shapes.Say("...");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				C.Wizard.AnimIdle = "Idle";
				C.Wizard.AnimTalk = "Talk";
				yield return C.Wizard.Say("Here's your book.");
			}
			else if(item == I.SpellbookTwo)
			{
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("My good friend, do you bring knowledge?");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("Ah, one of the books I was containing.");
				yield return C.Wizard.Say("This is a more advanced text.");
				yield return E.WaitSkip();
		
				C.Wizard.AnimIdle = "AltIdle";
				C.Wizard.AnimTalk = "AltTalk";
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("Let us see....");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Wizard.Say("This book details rituals for the most devout followers of Vesta.");
				yield return C.Wizard.Say("They hoped that their hearths would act as invitations,");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("They prayed the Goddess would come to them.");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Wizard.Say("The rituals require a hearth of Vesta to already be summoned.");
				yield return C.Wizard.Say("And then, to bring about a portal to her doorstep...");
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("You must acquire Angel's Blood and Hair of Lavinia...");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Wizard.Say("While the book says nothing of Angels,");
				yield return C.Wizard.Say("Apparently, this Lavinia was one of Vesta's first followers,");
				yield return C.Wizard.Say("The legends say that she became fire, she became a hearth,");
				yield return C.Wizard.Say("Which had led glory and a golden age to her city.");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("Huh.");
				yield return E.WaitSkip();
				C.Wizard.AnimIdle = "Idle";
				C.Wizard.AnimTalk = "Talk";
		
				yield return C.Wizard.Say("Here's the book.");
				yield return C.Wizard.Say("Comrade, I don't know what you're planning,");
				yield return C.Wizard.Say("But I believe summoning Vesta wouldn't be smart.");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("She's, uh, not keen to this place.");
				yield return E.WaitSkip();
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("Not after what happened with the High Witch.");
			}
			else if(item == I.InversionScroll)
			{
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("How did this come into your possession?");
				yield return C.Wizard.Say("Last I saw this, it was irreversibly burnt to a crisp.");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("My good friend, you are so impressive.");
				yield return C.Wizard.Say("How relieved I am to be your most trusted ally.");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Wizard.Say("That being said, I would prefer you keep the scroll.");
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("Such magic is quite the temptation...");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("It is what drove the High Witch to her ultimate demise.");
				yield return C.Wizard.Say("Following its instructions without further consideraiton, well...");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("It's a recipe for death.");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("Please, be careful with that.");
			}
			else if(item == I.MirrorScroll)
			{
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("Huh? What's this?");
				yield return C.Wizard.Say("How could such magic evade my detection?");
				yield return C.Wizard.Say("Once again, your frog senses surpass mine of a human.");
				yield return C.Wizard.Say("What would I do without you, friend?");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("Well, let's take a look, shall we?");
				C.Wizard.AnimIdle = "AltIdle";
				C.Wizard.AnimTalk = "AltTalk";
		
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("This is interesting...");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("It appears to have been written by the High Witch herself.");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("She first divides life into platonic forms.");
				yield return C.Wizard.Say("Quite the thinker, she was.");
				yield return C.Wizard.Say("Then she supposes that... huh...");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("That reflections are, um, susceptible to collapse...");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("And, uh... well...");
		
				C.Wizard.AnimIdle = "Idle";
				C.Wizard.AnimTalk = "Talk";
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("I hate to admit it, but...");
				yield return C.Wizard.Say("But this reads like nonsense to me.");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("Trading spots with a mirror? Time travel and resurrection?");
				yield return C.Wizard.Say("And what of this jumbling she speaks of?");
				yield return E.WaitSkip();
				yield return C.Wizard.Say("No wonder she was destroyed.");
				Audio.Play("wizard_talk");
				yield return C.Wizard.Say("She was insane.");
			}
		
		
		}
		
		
		
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{

		yield return E.Break;
	}
}