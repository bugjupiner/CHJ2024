using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryConception : InventoryScript<InventoryConception>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		if(!G.Conception.Visible) G.Conception.Show();
		else G.Conception.Hide();
		yield return E.ConsumeEvent;
		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{

		yield return E.Break;
	}
}