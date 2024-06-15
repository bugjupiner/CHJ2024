using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryDollHead : InventoryScript<InventoryDollHead>
{


	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{
		if (item == I.DollBody)
		{
			Audio.Play("doll_combine");
			C.Shapes.AddInventory("Doll");
			C.Shapes.RemoveInventory("DollHead");
			C.Shapes.RemoveInventory("DollBody");
		
			I.DollBody.Active = false;
			yield return C.Display("Made Doll");
			yield return C.Shapes.Say("What's this for?");
		}
		yield return E.Break;
	}

	IEnumerator OnInteractInventory( IInventory thisItem )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Shapes.Say("Where's the body?");
		yield return E.Break;
	}
}