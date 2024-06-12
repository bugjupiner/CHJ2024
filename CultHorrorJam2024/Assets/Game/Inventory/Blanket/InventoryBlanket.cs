using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryBlanket : InventoryScript<InventoryBlanket>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Shapes.Say("Feels comfy.");
		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{
		if (item == I.Conception)
		{
			G.Conception.Show();
			yield return E.ConsumeEvent;
		}
		yield return E.Break;
	}
}