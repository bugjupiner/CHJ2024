using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryDormantSoul : InventoryScript<InventoryDormantSoul>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Display("An unmistakable kind of restless energy.");
		yield return E.Break;
	}
}