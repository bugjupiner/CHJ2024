using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryGlass : InventoryScript<InventoryGlass>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Shapes.Say(" It's see through!");
		yield return E.Break;
	}
}