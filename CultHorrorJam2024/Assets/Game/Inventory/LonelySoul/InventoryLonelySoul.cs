using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryLonelySoul : InventoryScript<InventoryLonelySoul>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("dormant_soul_pickup");
		yield return C.Shapes.Say("This thing belongs with the others...");
		yield return E.Break;
	}
}