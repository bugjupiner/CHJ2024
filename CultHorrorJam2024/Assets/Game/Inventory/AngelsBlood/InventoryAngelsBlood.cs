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
}