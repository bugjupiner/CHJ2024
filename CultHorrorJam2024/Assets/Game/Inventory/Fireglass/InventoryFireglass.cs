using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryFireglass : InventoryScript<InventoryFireglass>
{


	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{
		yield return E.Break;
	}

	IEnumerator OnInteractInventory( IInventory thisItem )
	{
		
		yield return E.Break;
	}
}