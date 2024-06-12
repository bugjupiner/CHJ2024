using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;

public class InventoryPamphlet : InventoryScript<InventoryPamphlet>
{

	public IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Display("A pamphlet with a strange symbol.");
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
