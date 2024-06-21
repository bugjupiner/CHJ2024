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
		yield return C.Shapes.Say("I think it needs to rest....");
		yield return E.Break;
	}

	IEnumerator OnInteractInventory( IInventory thisItem )
	{

		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{

		yield return E.Break;
	}
}