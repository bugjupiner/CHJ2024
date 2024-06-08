using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterAngel : CharacterScript<CharacterAngel>
{


	IEnumerator OnInteract()
	{
		yield return C.Shapes.WalkTo(C.Angel);
		yield return C.Angel.Say("Hehehehe");
		yield return E.Break;
	}
}