using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryFacelessSoul : InventoryScript<InventoryFacelessSoul>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("dormant_soul_pickup");
		yield return C.Shapes.Say("Where do you belong?");
		yield return E.Break;
	}
}