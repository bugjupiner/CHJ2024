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
		Debug.Log("used");
		yield return E.Break;
	}

	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Shapes.Say("I'm confused.");
		yield return C.Shapes.Say("Is this a rock, or a portal?");
		yield return E.Break;
	}
}