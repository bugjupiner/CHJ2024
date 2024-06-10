using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterRecruit : CharacterScript<CharacterRecruit>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.Player.FaceLeft();
		yield return C.Recruit.Say("GET AWAY FROM ME!!!");
		yield return C.Recruit.PlayAnimation("StabR");
		yield return E.Break;
	}
}