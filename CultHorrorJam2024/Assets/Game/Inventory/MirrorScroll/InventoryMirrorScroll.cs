using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryMirrorScroll : InventoryScript<InventoryMirrorScroll>
{


	IEnumerator OnInteractInventory( IInventory thisItem )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Shapes.Say("'Mirrors: Sanctuary for the Soul'");
		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{

		yield return E.Break;
	}
}