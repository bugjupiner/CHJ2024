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
			yield return C.Wizard.Say("This isn't right.");
			yield return C.Wizard.Say("You're to be imprisoned!");
			yield return E.WaitSkip();
			yield return C.Wizard.Say("Oh well.");
		}
		else
		{
			yield return C.Wizard.Say("Ah, my trusty familiar!");
			yield return C.Wizard.Say("Catch any flies lately? Bwa ha!");
			yield return E.WaitSkip();
			yield return C.Wizard.Say("Oh is that so? Several? Why, they must fear you, surely.");
			yield return E.WaitSkip();
			yield return C.Wizard.Say("Now that you're here, suppose those spell bubbles are of no use.");
			yield return C.Wizard.Say("Yes, yes. Your frog magic shall keep the evil at bay.");
		
			Globals.wizardSpellBroken = true;
		
			yield return E.WaitSkip();
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
		
			C.Wizard.AnimIdle = "Dead";
			C.Wizard.AnimTalk = "Dead";
			yield return C.Wizard.Say("GAH!");
		
			C.Wizard.Clickable = false;
			Globals.wizardSpellBroken = true;
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Display("The Wizard's Spell Was Broken");
		}
		
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{

		yield return E.Break;
	}
}