using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;

public class InventoryPamphlet : InventoryScript<InventoryPamphlet>
{

	public IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Shapes.Say("This pamphlet has a weird symbol on top.");
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
