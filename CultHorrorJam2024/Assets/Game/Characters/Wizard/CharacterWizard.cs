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
		yield return C.Wizard.Say("This isn't right.");
		yield return C.Wizard.Say("You're to be imprisoned!");
		yield return E.WaitSkip();
		yield return C.Wizard.Say("Oh well.");
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Knife || item == I.Rubble)
		{
			C.Wizard.AnimIdle = "Dead";
			C.Wizard.AnimTalk = "Dead";
			yield return C.Wizard.Say("GAH!");
		
			C.Wizard.Clickable = false;
			Globals.wizardSpellBroken = true;
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Shapes.Say("Somethings changed...");
		}
		
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{

		yield return E.Break;
	}
}