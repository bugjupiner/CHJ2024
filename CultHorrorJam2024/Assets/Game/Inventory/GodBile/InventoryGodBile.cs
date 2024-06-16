using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryGodBile : InventoryScript<InventoryGodBile>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("god_bile_pickup");
		yield return C.Shapes.Say("It's gross.");
		yield return E.Break;
	}
}