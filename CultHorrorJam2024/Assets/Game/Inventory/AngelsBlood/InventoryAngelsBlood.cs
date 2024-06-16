using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryAngelsBlood : InventoryScript<InventoryAngelsBlood>
{


	IEnumerator OnInteractInventory( IInventory thisItem )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("past_angel_hurt");
		yield return C.Shapes.Say("Feels powerful.");
		yield return E.Break;
	}
}