using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterWorm : CharacterScript<CharacterWorm>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("Um...");
		yield return C.Worm.Say("Family...");
		yield return E.WaitSkip();
		C.Worm.AnimTalk = "Excited";
		yield return C.Worm.Say("Happy Family!");
		yield return E.WaitSkip();
		C.Worm.AnimTalk = "Talk";
		yield return E.WaitSkip();
		yield return C.Worm.Say(" Not even... a single smile?");
		yield return E.Break;
	}
}