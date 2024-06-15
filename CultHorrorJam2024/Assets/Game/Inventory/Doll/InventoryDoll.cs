using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryDoll : InventoryScript<InventoryDoll>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Shapes.Say("Just a normal doll.");
		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractInventory( IInventory thisItem )
	{

		yield return E.Break;
	}
}