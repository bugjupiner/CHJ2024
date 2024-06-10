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
		yield return C.Shapes.Say("I know you...");
		yield return C.Shadow.Say("That's right.");
		yield return E.WaitSkip();
		yield return C.Shadow.Say("Like looking in a mirror.");
		yield return E.Break;
	}
}