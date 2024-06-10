using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterOmen : CharacterScript<CharacterOmen>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.Player.FaceRight();
		yield return C.Omen.Say("I SEE IT!");
		yield return E.WaitSkip();
		yield return C.Omen.Say("MY CITY!");
		yield return E.WaitSkip();
		yield return C.Omen.Say(" MY HOME!");
		yield return E.Break;
	}
}