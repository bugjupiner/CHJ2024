using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryDormantSoul : InventoryScript<InventoryDormantSoul>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("dormant_soul_pickup");
		yield return C.Shapes.Say("Restless energy...");
		yield return E.Break;
	}
}