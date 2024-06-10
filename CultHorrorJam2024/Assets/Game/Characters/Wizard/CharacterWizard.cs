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
}