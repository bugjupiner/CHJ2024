using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterShapes : CharacterScript<CharacterShapes>
{


	IEnumerator OnInteract()
	{
		if(Globals.jumbled == true)
		{
			Globals.jumbled = false;
			C.Shapes.AnimIdle = "Idle";
			C.Shapes.AnimWalk = "Walk";
			}
		else
		{
			if(Globals.jumbled == false)
			{
				Globals.jumbled = true;
				C.Shapes.AnimIdle = "Jumble";
				C.Shapes.AnimWalk = "Jumble";
			}
		}
		
		Region("Bars").Walkable = Globals.jumbled;
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{

		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{

		yield return E.Break;
	}
}