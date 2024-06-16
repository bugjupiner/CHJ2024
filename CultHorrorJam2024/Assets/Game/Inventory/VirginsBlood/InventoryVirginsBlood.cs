using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryVirginsBlood : InventoryScript<InventoryVirginsBlood>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("recruit_ow");
		yield return C.Shapes.Say("Poor guy.");
		yield return E.Break;
	}
}