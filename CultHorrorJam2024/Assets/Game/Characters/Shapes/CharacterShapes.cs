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
		
		R.Cells.GetRegion("Bars").Walkable = Globals.jumbled;
		R.Basement.GetRegion("Bars").Walkable = Globals.jumbled;
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{

		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if (item == I.Pamphlet)
		{
			yield return C.Display("An invitation of sorts to something called The Circle of Vesta.");
			yield return C.Display("According to this, Vesta is some pagan goddess of house fires.");
			yield return C.Display("No, wait, they're actually called 'hearths'.");
		}
		yield return E.Break;
	}
}