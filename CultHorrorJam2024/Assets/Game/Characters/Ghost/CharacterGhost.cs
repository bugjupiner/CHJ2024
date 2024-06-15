using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterGhost : CharacterScript<CharacterGhost>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.Ghost.Say("You must...");
		yield return C.Ghost.Say("See through his lies...");
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{
		yield return C.Shapes.Say("A ghost!");
		yield return E.Break;
	}
}