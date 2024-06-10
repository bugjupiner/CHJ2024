using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterFinger : CharacterScript<CharacterFinger>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Finger.Say("...");
		yield return E.Break;
	}
}